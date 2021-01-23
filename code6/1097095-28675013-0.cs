    private static HtmlGenericControl CreateHtmlInputCheckBoxControl(Filters filter)
    {
        HtmlGenericControl column = CreateColumn(filter);
        column.Controls.Add(new HtmlInputCheckBox { ID = string.Format("{0}{1}", filter.ID, filter.ReportID), Checked = false });
        HtmlGenericControl l = new HtmlGenericControl("label"){InnerText=filter.Caption};       
        l.Attributes["for"]= string.Format("{0}{1}", filter.ID, filter.ReportID);
        column.Controls.Add(l);
        return column;
    }
