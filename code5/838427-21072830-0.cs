     private void SaveTimeWindow(TimeWindow[] time, string filePath)
        {
            //Open a file stream 
            System.IO.FileStream fs = new System.IO.FileStream(filePath, System.IO.FileMode.Create);
            // Create a xml Serializer object
            System.Xml.Serialization.XmlSerializer xmlSer = new System.Xml.Serialization.XmlSerializer(typeof(TimeWindow[]));
            xmlSer.Serialize(fs, time);
            // Close the file stream
            fs.Close();         
        }
