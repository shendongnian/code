        private void btnImport_Click(object sender, EventArgs e)
        {
           CCMServiceRef.DataFileStream obj = new CCMServiceRef.DataFileStream()
           {
              FileName = _FileName,
              StreamData = GetStream(_FilePath)
           };
           Program.serviceManager.Client.ImportScript(obj);
        }
        private Stream GetStream(string filePath)
        {
            System.IO.MemoryStream data = new System.IO.MemoryStream();
            System.IO.Stream str = File.OpenRead(filePath);
            str.CopyTo(data);
            data.Seek(0, SeekOrigin.Begin);
            byte[] buf = new byte[data.Length];
            data.Read(buf, 0, buf.Length);
            return data;
        }
