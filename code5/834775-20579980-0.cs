    private void button1_Click(object sender, EventArgs e)
    {
        var webget = new HtmlWeb();
        var doc = webget.Load("http://www.dmp.gov.bd/application/index/pressdetails/press_159");
    
        HtmlNode node = doc.DocumentNode.SelectSingleNode("//div[@class='span8 inner_mess']");
    
        TraverseNodes(node.ChildNodes);
    }
    
    private void TraverseNodes(HtmlNodeCollection nodes)
    {
        foreach (HtmlNode node in nodes)
        {
            textBox1.Text += node.InnerText;
    
            TraverseNodes(node.ChildNodes);
        }
    }
