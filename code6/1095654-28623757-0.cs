    Form main = (Form)CommandFacade.IModuleHandler.IHost;
    Assembly Assembly = (Assembly)IArticles.Assembly;
    Type Type = Assembly.GetType("DAMS.Module.ARTICLES.Articles_Search", true);
    Articles_Search searchForm = (Articles_Search)Activator.CreateInstance(Type);        
    searchForm.MdiParent = main;
    searchForm.StartPosition = FormStartPosition.CenterScreen;
    searchForm.FormBehavior["Control"] = "Value";
    searchForm.HiddenColumns.Add("article_cost");
    searchForm.Show();
