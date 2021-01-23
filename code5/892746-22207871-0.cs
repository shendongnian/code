       protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
       {      
           GridViewRow row = (GridViewRow)GridView1.Rows[e.RowIndex];
           string age = row.Cells[2].Text.Trim(); // i get correct value for age here
       
           XmlDocument doc2 = new XmlDocument();
           doc2.Load(Server.MapPath("names.xml")); 
           XmlNode nodeList = doc2.SelectSingleNode(string.Format("PERSONES/person[age='{0}']", age));
           doc2.DocumentElement.RemoveChild(nodeList);
           doc2.Save(Server.MapPath("names.xml"));
           getdata();   
       }
