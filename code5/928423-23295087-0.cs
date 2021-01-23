    protected HtmlGenericControl CreateDivRowHeader(string id)
    {
        HtmlGenericControl divRowHeader = new HtmlGenericControl("div");
        divRowHeader.Style.Add(HtmlTextWriterStyle.Width, "323px");
        divRowHeader.Style.Add(HtmlTextWriterStyle.MarginTop, "2px");
        divRowHeader.Style.Add(HtmlTextWriterStyle.MarginLeft, "45px");
        divRowHeader.Style.Add(HtmlTextWriterStyle.Height, "30px");
        divRowHeader.Style.Add("border-top", "solid 3px lightgray");
        divRowHeader.Style.Add("border-bottom", "solid 3px lightgray");
        divRowHeader.Style.Add("border-right", "solid 3px lightgray");
        divRowHeader.Style.Add("border-left", "solid 3px lightgray");
        divRowHeader.ID=id;
        return divRowHeader;
    }
    
    //now you can reuse the code
    divTabRessources.Controls.Add(CreateDivRowHeader("control1"));
    divTabInterim.Controls.Add(CreateDivRowHeader("control2"));
