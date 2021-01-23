		public static bool Delete(FileInfo fi)
		{
			int retries = 40;
			bool ret = false;
			SpinWait _sw = new SpinWait();
			while (!ret && retries-- > 0)
			{
				if (fi?.Exists ?? false)
				{
					fi.IsReadOnly = false;
					try
					{
						fi.Delete();
						ret = true;
					}
					catch (IOException) { _sw.SpinOnce(); }
				}
				else break;
			}
			return ret;
		}
