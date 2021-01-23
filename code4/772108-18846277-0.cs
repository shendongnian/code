    	private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
		{
			Job currentJob = (Job)e.Argument;
			SavedDocument document = currentJob.SavedDocument;
			DocumentConverter<Bitmap> converter = DocumentConverterFactory<Bitmap>.getDocumentConverterForType(Path.GetExtension(document.Document_Name).Replace('.', ' ').Trim().ToUpper(), typeof(Bitmap));
			Image jobCardImage = (Image)converter.convertDocument(FileUtils.createTempFile(document.Document_DocumentData.ToArray(), document.Document_Name));
			e.Result = jobCardImage;
		}
		
		private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
			if (e.Error != null)
            {
                //error-handling
            }
            else if (e.Cancelled)
            {
                //cancel-handling  
            }
            else
            {
            	Image jobCardImage = e.Result as Image;
            	if (jobCardImage != null)
					this.picJobCard.Image = jobCardImage;
            }
            
            this.picLoadingJobCard.Visible = false;
		}
		
		
		private void loadJobSheet(Job currentJob)
	    {
	
	        if (this.backgroundWorker.IsBusy)
	        	this.backgroundWorker.CancelAsync();
	
	        this.backgroundWorker.RunWorkerAsync(currentJob);
	        this.picLoadingJobCard.Visible = true;
	    }
