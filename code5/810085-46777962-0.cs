		public static bool Delete(FileInfo fi)
		{
			bool ret = true;
			if (fi?.Exists ?? false)
			{
				int retries = 40;
				SpinWait _sw = new SpinWait();
				ret = false;
				fi.IsReadOnly = false;
				while (!ret && retries-- > 0)
				{
					try
					{
						fi.Delete();
						ret = true;
					}
					catch (IOException) { _sw.SpinOnce(); }
				}
			}
			return ret;
		}
