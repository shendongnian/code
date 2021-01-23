    public List<myDetails> GetAddressDetails(int id)
    {
        List<myDetails> mydetails = new List<myDetails>();
        myDetails details;
        try
        {
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    details = new myDetails(
                                  (reader.GetString(reader.GetOrdinal("FieldName")));
                    mydetails.Add(details);
            }
            rdr.Close();
            return mydetails;
        }
    }
    var item = clib.GetAddressDetails(int id);
    if (item != null)
    {
        StringBuilder htmlStr = new StringBuilder("");
        htmlStr.Append("<center><h2 class='headings'>Addresses</h2>");
        htmlStr.Append("<table border='1' cellpadding='3'>");
        foreach(var detail in item)
        {
            htmlStr.Append("<tr>");
            htmlStr.Append("<td width='25px'>" + detail.FieldName + "</td><tr>");
            htmlStr.Append("</tr>");
        }
        
        htmlStr.Append("</table></center><br/>");
        divAddresses.InnerHtml = htmlStr.ToString(); 
    }
