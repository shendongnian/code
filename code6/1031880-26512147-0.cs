      using (XmlReader reader = XmlReader.Create("generator_0000001.xml"))
      {
         List<Vector3> verticesList = new List<Vector3>();
         while (reader.Read())
         {
             if (reader.IsStartElement())
             {
                switch (reader.Name)
                {
                  case "Real64List":
                  if (reader.Read())
                  {
                    float vertices = Convert.ToInt64(reader.Value.Trim());
                    Vector3 oVert = new Vector3(vertices);
                    verticesList.Add(oVert);
                  }
                  break;
                }
             }
          }
