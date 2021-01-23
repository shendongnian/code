     try  {
            // Start a Timer                     
           // Write from the source to the destination.
                    bulkCopy.WriteToServer(reader);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    // Close the SqlDataReader. The SqlBulkCopy 
                    // object is automatically closed at the end 
                    // of the using block.
                    reader.Close();
                   // Stop the Timer
                }
