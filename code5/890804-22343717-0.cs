    public bool firstcat; // defined at before Page_Load method
    public int temp_cat;  // defined at before Page_Load method
    for (int i = 0; i < dt.Rows.Count; i++)
    {
        if (temp_cat != Convert.ToInt32(dt.Rows[i]["food_cat"]))
        {
            if (i > 0 && !firstcat)
                content.InnerHtml += "</ul>"; //solution's most critic point is here
            content.InnerHtml += "<ul>"
        }
        content.InnerHtml += String.Format("<li>{0}</li>", dt.Rows[i]["food"].ToString());
        temp_cat = Convert.ToInt32(dt.Rows[i]["food_cat"]);
    }
