    private void LoadNewsArticles()
    {
        List<MyNewsArticle> newsArticles = GetNewsArticles();
    
        foreach(MyNewsArticle a in newsArticles)
        {
            TreeNode node = new TreeNode(a.Title)
            node.Tag = a;
            treeView1.Nodes.Add(node);
        }
    }
