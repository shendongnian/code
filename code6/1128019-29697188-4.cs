        //Parses an XML string and retrieves a list of Marker objects. Should probably go in a utility class somewhere, not in code behind
        protected void GetData(string strRsult)
        {
            List<Marker> markers = new List<Marker>();
            XmlDataDocument xmlDataDoc = new XmlDataDocument();
            xmlDataDoc.LoadXml(strRsult);
        	//This line write script init in your html page
        	Literal1.text = "<script type=\"text/javascript\">var markers = [";
        	
            foreach (XmlNode n in xmlDataDoc.DocumentElement.GetElementsByTagName("Property"))
            {
                if (n.HasChildNodes)
                {
    //for any item you write directly the element{ tile:'yourTile', lat:'yourLat', lng:'yourLng' }
                    foreach (XmlNode childNode in n)
                        {
                            if (childNode.Name=="GEOData")
                            {
                                literal1.text += "{title: '"+childNode.Attributes["City"].Value+"', lat: '"+childNode.Attributes["Longitude"].Value+"', lng: '"+childNode.Attributes["Latitude"].Valu+"'}";                        
                            }
                        }
                }
            }
        	//Write the scripts end
        	Literal1.text += "];</script>";
        }
