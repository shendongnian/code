    IPageData pageData;
    switch(smartFormId) {
        case EktronSmartForms.StandardPage:
            pageData = (EkXml.Deserialize(typeof(StandardPage), ContentData.Html) as StandardPage);
            break;
        ...
    }
    
    var sections = pageData.LeftContent.AdditionalSection;
    title = pageData.LeftContent.ParentBreadcrumbTitle;
    if (sections != null)
    {
        foreach (var item in sections)
        {
            tempLD = new LinkData();
            tempLD.Text = item.SectionTitle;
            tempLD.Class = "class=\"sub-parent\"";
            autoData.Add(tempLD);
            if (item.Link != null && item.Link.Count() > 0)
            {
                foreach (var child in item.Link)
                {
                    tempLD = new LinkData();
                    tempLD.Text = child.a.OuterXML;
                    tempLD.Link = child.a.href;
                    tempLD.Class = "class=\"\"";
                    autoData.Add(tempLD);
                }
            }
        }
    }
