    StringBuilder sb  = new StringBuilder();  //before while loop
    StringBuilder sb1  = new StringBuilder();  //before while loop
    XmlReader ReadFile = XmlReader.Create(AgentConfig.FileName);
        while (ReadFile.Read())
        {
            if ((ReadFile.NodeType == XmlNodeType.Element) && (ReadFile.Name == "endpoint"))
            {
                if (ReadFile.HasAttributes)
                {
                    sb.Append(ReadFile.GetAttribute("address") + " ");
                    sb1.Append(ReadFile.GetAttribute("address") + " ");
                    
                }
            }
        }
    //Then after your loop
    textBox2.Text  = sb.ToString();
    textBox3.Text  = sb1.ToString();
