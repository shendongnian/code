    //Move this outside of the for-loop
    DataClassesDataContext tb = new DataClassesDataContext();
    for (int i = 0; i < dv; i++)
        {
            var ctitle = (from cat in tb.dml_np_Categories
                          where cat.Pk_Category_Id == (i+1)
                          select cat.Category_Title).First();
            HtmlGenericControl adddiv = new HtmlGenericControl("div");
            adddiv.Attributes.Add("class", "category");
            HtmlGenericControl addh3 = new HtmlGenericControl("h3");
            addh3.Attributes.Add("class", "h3");
            addh3.InnerText = ctitle.ToString();
            catblock.Controls.Add(adddiv);
            adddiv.Controls.Add(addh3);
    }
