            StreamReader sourceStream = new StreamReader(@"C:\\Users\\L\\Desktop\\data.xml");
            
            //Get Preamble and File Contents
            byte[] bom = Encoding.Unicode.GetPreamble();
            byte[] content = Encoding.Unicode.GetBytes(sourceStream.ReadToEnd());
            //Create Destination array
            byte[] fileContents = new Byte[bom.Length + content.Length];
            //Copy arrays into destination appending bom if available
            Array.Copy(bom, 0, fileContents, 0, bom.Length);
            Array.Copy(content, 0, fileContents, bom.Length, content.Length);
            request.ContentLength = fileContents.Length;
            long ftp_vel = request.ContentLength;
            Stream requestStream = request.GetRequestStream();
            requestStream.Write(fileContents, 0, fileContents.Length);
            requestStream.Close();
            FtpWebResponse response = (FtpWebResponse)request.GetResponse();
            if (original_vel == ftp_vel)
            {
                response.Close();
            }
            else
            {
                Odesilani();
            }
