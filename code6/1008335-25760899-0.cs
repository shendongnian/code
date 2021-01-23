     XmlReader reader = XmlReader.Create("test.xml");
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element)
                    if (reader.Name == "Ad_Id")
                    {
                        reader.Read();
                        string sAd_ID = reader.Value;
                        string sAd_Ref = string.Empty;
                        
                        if (reader.ReadToFollowing("Ad_Ref"))
                        {
                            reader.Read();
                            sAd_Ref = reader.Value;
                        }
                    }
            }
 
