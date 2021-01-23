          using (StreamReader reader = new StreamReader(openFileDialog.FileName))
                    {
                        // Найдем количество полигонов в Xml-файле
                        XmlDocument loadedXml = new XmlDocument();
                        string directory = openFileDialog.FileName;
                        loadedXml.Load(reader); **// I USE IT, BUT NO CLOSE!**
                        XmlNodeList polygonNodeList = loadedXml.GetElementsByTagName("CustomPolygon");
                   if (polygonNodeList.Count > 1)
                        for (int i = 0; i < polygonNodeList.Count; i++)
                        {
                           // List <CustomPolygon> listcp= new List<CustomPolygon>();
                 XmlSerializer xmlReader = new XmlSerializer(typeof (List<CustomPolygon>));
                     var listcp = (List<CustomPolygon>)xmlReader.Deserialize(reader);
                            }
                   else
                        {
                            XmlSerializer xmlReaderResult = new XmlSerializer((typeof (CustomPolygon)));
                            CustomPolygon loadedResultPolygon = (CustomPolygon) xmlReaderResult.Deserialize(reader); **// MORE OVER I USE IT IN THIS PLACE, WITHOUT CLOSE()** BEFORE
                            resultOfTwoPolygonsUnion = loadedResultPolygon;
                        }
                        reader.Close();
                    }
                                                                                                 
               
