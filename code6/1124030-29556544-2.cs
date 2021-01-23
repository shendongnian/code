    public class Service1 : IService1
        {
        
       
        /// <summary>
        /// <see cref="IUpload.Upload"/>
        /// </summary>
        /// <param name="token">This parameter is ignored.</param>
        /// <param name="data">Data being uploaded.</param>
        /// <param name="callback">Async callback.</param>
        /// <param name="asyncState">Async user state.</param>
        public IAsyncResult BeginAsyncUpload(Stream data, AsyncCallback callback, object asyncState)
        {
            return new CompletedAsyncResult<Stream>(data);
        }
        /// <summary>
        /// <see cref="IUpload.EndAsyncUpload"/>
        /// </summary>
        public void EndAsyncUpload(IAsyncResult ar)
        {
            Stream data = ((CompletedAsyncResult<Stream>)ar).Data;
            _streamToFile(data);
        }
        /// <summary>
        /// Writes the uploaded stream to a file.
        /// </summary>
        /// <remarks>
        /// This function is just to prove a test.  This simple saves the uploaded data into a file named &quot;upload.dat&quot; in a subdirectory
        /// whose name is created by a generated guid.
        /// </remarks>
        private static void _streamToFile(Stream data)
        {
            // create name of subdirectory
            string subDir = Guid.NewGuid().ToString("N");
            // get full path to and create the directory to save file in
            string uploadDir = Path.Combine(Path.GetDirectoryName(typeof(Service1).Assembly.Location), subDir);
            Directory.CreateDirectory(uploadDir);
            // 64 KiB buffer
            byte[] buff = new byte[0x10000];
            // save the file in chunks
            using (FileStream fs = new FileStream(Path.Combine(uploadDir, "upload.xml"), FileMode.Create))
            {
                int bytesRead = data.Read(buff, 0, buff.Length);
                while (bytesRead > 0)
                {
                    fs.Write(buff, 0, bytesRead);
                    bytesRead = data.Read(buff, 0, buff.Length);
                }
            }
        }
