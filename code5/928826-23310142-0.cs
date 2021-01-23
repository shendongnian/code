        private void BeginOpenReadCallback(IAsyncResult ar)
        {
            AsyncObject args = (AsyncObject)ar.AsyncState;
            FtpClient conn = args.conn;
            Stream istream = conn.EndOpenRead(ar);
            using (System.IO.FileStream fs = System.IO.File.Create(@"C:\temp\" + args.filename))
            {
                byte[] bytes = new byte[istream.Length];
                int bytesread = istream.Read(bytes, 0, bytes.Length);
                fs.Write(bytes, 0, bytesread);
            }
        }
