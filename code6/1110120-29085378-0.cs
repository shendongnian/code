    for (int i = 1; i < 5; i++)
    {
        HtmlGenericControl table = new HtmlGenericControl("table");
        table.ID = "Serie_table_" + i;
        table.Attributes.Add("class", "Serie_table");
        divSerie_lists.Controls.Add(table);
    }
