    private void SplitUnwantedHeader(string sourceFile, string destinationFile)
        {
            byte[] fByte = new byte[65534];                                                             //Declare 64k byte for read/write buffer
            long headerToSplit = 128;                                                                   //Declare the point where to start reading
            int bytesRead = 0;                                                                          //Declare total bytes read
            try
            {
                using (var fr = new FileStream(sourceFile, FileMode.Open, FileAccess.Read))             //Open source file for reading
                using (var fw = new FileStream(destinationFile, FileMode.Create, FileAccess.Write))     //Create and open destination file for writing
                {
                    fr.Position = headerToSplit;                                                        //Set reading position of source file in bytes
                    do
                    {
                        bytesRead = fr.Read(fByte, 0, fByte.Length);                                    //Read 64k bytes from source file
                        fw.Write(fByte, 0, bytesRead);                                                  //Write 64k bytes to destination file
                    } while (bytesRead != 0);                                                           //Loop until there is no more bytes to read
                }               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);                                   //Catch exception (if any) and display to user
            }
        }
