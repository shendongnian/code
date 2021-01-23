    YourDBDataContext dataContext = new YourDBDataContext();
    ...
    Webpage page = new Webpage();
    page.id = "p1";
    page.url = "http://stackoverflow.com";
    dataContext.InsertOnSubmit(page);
    Tab tab = new Tab();
    tab.id = "t1";
    tab.webpage = page;
    dataContext.InsertOnSubmit(tab);
    dataContext.SubmitChanges();
