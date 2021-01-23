    public List<ReceiverPoint> ReadFile()
            {
                var receiverList = new List<ReceiverPoint>();
    
                Console.WriteLine("Now in read file method :" + "");
    
                var xmldoc = new XmlDocument();
                xmldoc.Load(@"D:\users\..\Downloads\ReceiverPoints.xml");
    
                XmlNamespaceManager nameSpaceManager = new XmlNamespaceManager(xmldoc.NameTable);
    
                //nameSpaceManager.AddNamespace ("ns", "http://schemas.datacontract.org/2004/07/AristotleService.Models");
                nameSpaceManager.AddNamespace("ns", "http://schemas.datacontract.org/2004/07/GTI.Aristotle.Web.Api.Models");
    
    
    
                XmlElement rootElement = xmldoc.DocumentElement;
    
                XmlNodeList nodeList = rootElement.SelectNodes("/ns:PagedDataInquiryResponseOfReceiverPointQ3ffICf5/ns:Items/ns:ReceiverPoint", nameSpaceManager);
    
               
                foreach (XmlNode childNode in nodeList)
                {
                    ReceiverPoint receiverPoint = new ReceiverPoint();
                    receiverPoint.CloseDate = childNode.SelectSingleNode("ns:CloseDate", nameSpaceManager).InnerText;
                    receiverPoint.CreateDate = childNode.SelectSingleNode("ns:CreateDate", nameSpaceManager).InnerText;
                    receiverPoint.CreateWho = childNode.SelectSingleNode("ns:CreateWho", nameSpaceManager).InnerText;
                    receiverPoint.Easting = childNode.SelectSingleNode("ns:Easting", nameSpaceManager).InnerText;
                    receiverPoint.Elevation = childNode.SelectSingleNode("ns:Elevation", nameSpaceManager).InnerText;
                    receiverPoint.IsDeployed = childNode.SelectSingleNode("ns:IsDeployed", nameSpaceManager).InnerText;
                    receiverPoint.IsManual = childNode.SelectSingleNode("ns:IsManual", nameSpaceManager).InnerText;
                    receiverPoint.LastModifyDate = childNode.SelectSingleNode("ns:LastModifyDate", nameSpaceManager).InnerText;
                    receiverPoint.Latitude = childNode.SelectSingleNode("ns:LatitudeWGS84", nameSpaceManager).InnerText;
                    receiverPoint.Line = childNode.SelectSingleNode("ns:Line", nameSpaceManager).InnerText;
                    receiverPoint.Longitude = childNode.SelectSingleNode("ns:LongitudeWGS84", nameSpaceManager).InnerText;
                    receiverPoint.ReceiverType = childNode.SelectSingleNode("ns:ReceiverType", nameSpaceManager).InnerText;
                    receiverPoint.Station = childNode.SelectSingleNode("ns:Station", nameSpaceManager).InnerText;
    
    
    
    
                    //Get all the values stored in the receiver point object
                    string station = receiverPoint.Station;
                    string line = receiverPoint.Line;
                    string elevation = receiverPoint.Elevation;
                    string latitude = receiverPoint.Latitude;
                    string longitude = receiverPoint.Longitude;
                    string isDeployed = receiverPoint.IsDeployed;
                    string easting = receiverPoint.Easting;
                    string receiverType = receiverPoint.ReceiverType;
                    string closeDate = receiverPoint.CloseDate;
                    string createDate = receiverPoint.CreateDate;
                    string createWho = receiverPoint.CreateWho;
                    string lastModifyDate = receiverPoint.LastModifyDate;
    
    
                    Console.WriteLine("String lat : " + latitude);
    
                    Console.WriteLine("String lon : " + longitude);
    
                    Console.WriteLine("String create date : " + createDate);
    
                    Console.WriteLine("String create who : " + createWho);
    
                    //Save the data to the db
                    //saveDataToDatabase(station, line, elevation, latitude, longitude, isDeployed, easting, receiverType, closeDate, createDate, createWho, lastModifyDate);
    
                    receiverList.Add(receiverPoint);
                }
    
                
                return receiverList;
            }
