    private void SplitUnwantedHeader(string sourceFile, string destinationFile)
        {
            long headerToSplit = 128;                                                                   //Declare the point where to start reading
            try
            {
                using (var fr = new FileStream(sourceFile, FileMode.Open, FileAccess.Read))             //Open source file for reading
                using (var fw = new FileStream(destinationFile, FileMode.Create, FileAccess.Write))     //Create and open destination file for writing
                {
                    fr.Position = headerToSplit;                                                        //Set reading position of source file in bytes
                    fr.CopyTo(fw, 65534);        //<-- Alternative for .NET 4.0
                }               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);                                   //Catch exception (if any) and display to user
            }
        }
