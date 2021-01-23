            [WebMethod]
            [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
            public static bool GetEdits(string PMID, string Drug, string Gene, string SNP)
            {
                bool alreadyInDB = false;
                
                using(System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Users\istrauss\Desktop\Log.txt"))
                {
                    DeveloprodDataClassDataContext masterDB = new DeveloprodDataClassDataContext();
                    
                    file.WriteLine("PMID: " + PMID + ", Drug: " + Drug + ", Gene: " + Gene + ", SNP: " + SNP);
    
                    //Other stuff
                    file.Flush();
                }    
                
                return alreadyInDB;
            }
