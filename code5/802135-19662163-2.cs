     private static IEnumerable<object[]> GetDocumentsData(string folderPath = @"filepath")
            {
                IList<object[]> collection = new List<object[]>();
                foreach (var file in Directory.GetFiles(folderPath, "*.xml"))
                {
                    try
                    {
                        /// do the proccecing here
                        collection.Add(/*your found elements*/);
                    }
    
                    catch(Exception e)
                    {
                        log.Error("Cant get collection", e);
    
                    }
                }
                return col;
            }
