        HtmlWeb getHtmlWeb = new HtmlWeb();
            
            HtmlDocument doc = getHtmlWeb.Load(txtbox.Text);
            string d = "//td[@class='d']";
            string h = "//td[@class='h']";
            string a = "//td[@class='a']";
            string p = "//table[@class='p']";
            HtmlNodeCollection ds = doc.DocumentNode.SelectNodes(d);
            HtmlNodeCollection hs = doc.DocumentNode.SelectNodes(h);
            HtmlNodeCollection as = doc.DocumentNode.SelectNodes(a);
            HtmlNodeCollection ps = doc.DocumentNode.SelectNodes(p);
    foreach (HtmlNode n in ds)
            {
                Outputlabel.Text += n.InnerHtml + "<br />"; 
            }
            foreach (HtmlNode h in hs)
            {
                Outputlabel.Text += h.InnerHtml + "<br />";
            }
            foreach (HtmlNode a in as)
            {
                Outputlabel.Text += a.Attributes["href"].Value + "<br />";
            }
            foreach (HtmlNode p in ps)
            {
                Outputlabel.Text += p.Attributes["title"].Value + "<br />";
            }
