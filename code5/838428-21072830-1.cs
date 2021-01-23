      private static TimeWindow[] LoadTime(string filePath)
            {
                //Open the XML file
                if (System.IO.File.Exists(filePath))
                {
                    System.IO.FileStream fs = new System.IO.FileStream(filePath, System.IO.FileMode.Open);
    
                    // First create a xml Serializer object
                    System.Xml.Serialization.XmlSerializer xmlSer = new System.Xml.Serialization.XmlSerializer(typeof(TimeWindow[]));
                    // Deserialize the Matrix object
                    TimeWindow[] time= (TimeWindow[])xmlSer.Deserialize(fs);
    
                    // Close the file stream
                    fs.Close();
                    return time;
                }
                else
                {
                    return null;
                }
    
            }
