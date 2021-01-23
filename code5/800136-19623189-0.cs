    public List<CGeoPoint> GetItin(CGeoPair latlongpair)
        {
            string RequestText = CreateRequest(latlongpair.GeoPoint1, latlongpair.GeoPoint2);
    
            XmlDocument locationsResponse = MakeRequest(RequestText);
            //Create namespace manager
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(locationsResponse.NameTable);
            nsmgr.AddNamespace("rest", "http://schemas.microsoft.com/search/local/ws/rest/v1");
    
            //Ovde kupim sve Itinerere čak i početnu i krajnju tačku. to se kasnije izbacuje
            XmlNodeList locationElements = locationsResponse.SelectNodes("//rest:ItineraryItem", nsmgr);
    
            List<CGeoPoint> itin = new List<CGeoPoint>();
            foreach (XmlNode location in locationElements)
            {
                decimal lat = decimal.Parse(location.SelectSingleNode(".//rest:Latitude", nsmgr).InnerText);
                decimal longit = decimal.Parse(location.SelectSingleNode(".//rest:Longitude", nsmgr).InnerText);
                string mantype = location.SelectSingleNode(".//rest:ManeuverType", nsmgr).InnerText;
                mantype = mantype.ToUpper();
    
                if (mantype == "KEEPSTRAIGHT" || mantype == "CONTINUEROUTE")
                {
                    //Do nothing... jump over
                }
                else
                {
                    CGeoPoint ll = new CGeoPoint(lat, longit);
                    itin.Add(ll);
                }
            }
            return itin;
        }  
