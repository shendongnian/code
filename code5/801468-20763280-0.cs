            public MemoryStream MemoryStreamMerger(List<MemoryStream> streams)
            {
    
                MemoryStream OurFinalReturnedMemoryStream;
                using (OurFinalReturnedMemoryStream = new MemoryStream())
                {
                    //Create our copy object
                    PdfCopyFields copy = new PdfCopyFields(OurFinalReturnedMemoryStream);
    
                    //Loop through each MemoryStream
                    foreach (MemoryStream ms in streams)
                    {
                        //Reset the position back to zero
                        ms.Position = 0;
                        //Add it to the copy object
                        copy.AddDocument(new PdfReader(ms));
                        //Clean up
                        ms.Dispose();
                    }
                    //Close the copy object
                    copy.Close();
    
                    //Get the raw bytes to save to disk
                    //bytes = finalStream.ToArray();
                }
                return new MemoryStream(OurFinalReturnedMemoryStream.ToArray());
    
            }
