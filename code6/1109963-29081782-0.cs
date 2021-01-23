		public static void Refresh(List<string> refreshPaths)
		{
			BackgroundWorker worker = new BackgroundWorker();
			worker.WorkerReportsProgress = true;
			worker.DoWork += delegate(object s, DoWorkEventArgs args)
			{
				List<string> filesPath = null;
				if (refreshPaths == null)
				{
					filesPath = DatabaseViewModel.Instance.Records.Select(record => record.Filepath).ToList();
				}
				else
				{
					filesPath = new List<string>(refreshPaths);
				}
				if (m_Repository != null && filesPath.Count > 0)
				{
					IList<FileSpec> lfs = new List<FileSpec>();
					int index = 0;
					foreach (DataRecord rec in DatabaseViewModel.Instance.Records)
					{
						lfs.Add(new FileSpec(new LocalPath(rec.Filepath), null));
						index++;
						if (index > MaxFilesIteration)
						{
							GetFileMetaDataCmdOptions opts = new GetFileMetaDataCmdOptions(GetFileMetadataCmdFlags.AllRevisions, null, null, 0, null, null, null);
							worker.ReportProgress(0, m_Repository.GetFileMetaData(lfs, null));
							lfs.Clear();
							index = 0;
						}
					}
					args.Result = m_Repository.GetFileMetaData(lfs, null); //pass the remaining results across
				}
			};
			worker.ProgressChanged += (sender, args) => PropegateMetaData(args.UserState as IList<FileMetaData>);
			worker.RunWorkerCompleted += (sender, args) => PropegateMetaData(args.Result as IList<FileMetaData>);
			worker.RunWorkerAsync();
		}
		private static void PropegateMetaData(IList<FileMetaData> fileList)
		{
			IList<FileMetaData> fileState = fileList as IList<FileMetaData>;
			if (fileState != null)
			{
				foreach (FileMetaData fmd in fileState)
				{
					DataRecord currentRecord = DatabaseViewModel.Instance.GetRecordByFilepath(fmd.LocalPath.Path);
					if (currentRecord != null)
					{
						switch (fmd.Action)
						{
							case FileAction.Add:
								currentRecord.P4Status = P4FileState.Added;
								break;
							case FileAction.Edit:
								currentRecord.P4Status = P4FileState.Edit;
								break;
							case FileAction.MoveAdd:
								currentRecord.P4Status = P4FileState.MoveAdd;
								break;
							default:
								currentRecord.P4Status = P4FileState.None;
								break;
						}
					}
				}
			}
		}
