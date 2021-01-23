       private void Save(double[][] m, string filePath)
        {
            //Open a file stream 
            System.IO.FileStream fs = new System.IO.FileStream(filePath, System.IO.FileMode.Create);
            // Create a xml Serializer object
            System.Xml.Serialization.XmlSerializer xmlSer = new System.Xml.Serialization.XmlSerializer(typeof(double[][]));
          
            xmlSer.Serialize(fs, m);
            // Close the file stream
            fs.Close();         
        }
