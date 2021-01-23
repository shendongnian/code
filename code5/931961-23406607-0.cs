    Page.Title = "Your Page title";
    //Page description
    HtmlMeta pagedesc = new HtmlMeta();
    pagedesc.Name = "Description";
    pagedesc.Content = textbox2.Text;
    
    Header.Controls.Add(pagedesc);
    //page keywords
    HtmlMeta pagekeywords = new HtmlMeta();
    pagekeywords.Name = "keywords";
    pagekeywords.Content = textbox1.Text;
    Header.Controls.Add(pagekeywords);
