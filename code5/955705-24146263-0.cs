    ArrayList ar_IMGID = new ArrayList();
    ArrayList ar_Ext = new ArrayList();
    
    while (transportFbReader.Read())
                {
                    ImageID = transportFbReader.GetString(0);
                    extention = transportFbReader.GetString(1);
                    //Open PDF:
                    if (ImageID != "")
                    {
                        
                        ar_IMGID.Add(ImageID);
                        ar_Ext.Add(extention);
                     }
                 }
    Session.Add("IMGID", ar_ImageID);
    Session.Add("Ext", ar_Ext);
