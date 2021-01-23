    using (var fStream = File.Create(strPath).Close())
                {
                     // these can go - (arguable you dont even need to do the close above, 
                     // but it's there for completeness's sake)
                     //fStream.Close();
                     //fStream.Dispose();
                }
                using(StreamWriter sWriter = new StreamWriter(strPath))
                {
                    sWriter.Write(strBuilder);
                    sWriter.Close();
                    //sWriter.Dispose(); - this can go too
                    Response.Clear();
                }
