    	public byte[] ImageDataFromResource(string r)
		{
			// Ensure "this" is an object that is part of your implementation within your Xamarin forms project
			var assembly = this.GetType().GetTypeInfo().Assembly; 
			byte[] buffer = null;
			using (System.IO.Stream s = assembly.GetManifestResourceStream(r))
			{
				if (s != null)
				{
					long length = s.Length;
					buffer = new byte[length];
					s.Read(buffer, 0, (int)length);
				}
			}
			return buffer;
		}
