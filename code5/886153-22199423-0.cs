    private void CreateNodes(int parentId)
    {
        DataTable dt = GetMenu(0);
        foreach(DataRow dr in dt.Rows)
        {
            writer.WriteStartElement("Node");
            writer.WriteStartAttribute("Id");
            writer.WriteValue(dr["MenuId"].ToString());
            writer.WriteEndAttribute();
    
            writer.WriteStartAttribute("Name");
            writer.WriteValue(dr["MenuName"].ToString());
            writer.WriteEndAttribute();
            
            **CreateNodes(Convert.ToInt32(dr["MenuId"]));**
            writer.WriteEndElement();
        }
    }
