            StringBuilder sb = new StringBuilder();
            ConnectionInfo c = new PasswordConnectionInfo(remoteIP, port, username, password);
            var sftp = new SftpClient(c);
            try
            {
                using (StreamReader reader = sftp.OpenText(fileName))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        sb.AppendLine(line);
                    }
                }
                File.WriteAllText(destinationFile, sb.ToString());
            }
            catch(Exception ex)
            {
                // procress exception
            }
