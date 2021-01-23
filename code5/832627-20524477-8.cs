    public ActionResult bestelProducten(List<ArticleOrderModel> model)
    {
        // Get your article list out of storage here
        
        foreach (ArticleOrderModel a in model)
        {
            // Here, I recommend that you put the order into the original Article objects,
            // I just will leave the original code here.
            DialogResult d = TopMostMessageBox.Show(string.Format("Article Number: {0} - Article: {1}", a.articleNumber, a.articleOrder), "Test", MessageBoxButtons.OK);
        }       
        return View();
    }
