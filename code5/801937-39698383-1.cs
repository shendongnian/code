    //Add reference DocX.dll
    using Novacode;
    
      // reference to the working document.
            static DocX gDocument;
    
     public void CreateWithOpenDoc(string _fileName, string _saveAs, int _LeadNo)
            {
                if (File.Exists(_fileName))
                {
    
                    gDocument = DocX.Load(_fileName);
    
    
                   
                    //--------------------- Make changes -------------------------------
    
                    // Strong-Type
                    Dictionary<string, string> changesList = GetChangesList(_LeadNo, dt.Rows[0]);
    
                    foreach (KeyValuePair<string, string> keyValue in changesList)
                    {
                        gDocument.ReplaceText(keyValue.Key.ToString().Trim(), keyValue.Value.ToString().Trim(), false);
                    }
    
                    //------------------------- End of make changes ---------------------
                     
    
                    gDocument.SaveAs(_saveAs);
    
                }
    
            }
