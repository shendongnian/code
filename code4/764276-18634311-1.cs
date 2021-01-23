    foreach (String projectType in ProjectsByProjectType.Keys)
    {
        HtmlTableRow trh = new HtmlTableRow();
        HtmlTableCell tdProjectType = new HtmlTableCell();
        tdProjectType.InnerHtml = "<b>"+projectType+"</b>";
        trh.Controls.Add(tdProjectType);
        tableLocal.Controls.Add(trh);
    }
