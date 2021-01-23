    var sqlResults = dataContext.MedicalArticles
    .Where (article => article.Topic == "influenza").ToList();
    Regex wordCounter = new Regex (@"\b(\w|[-'])+\b");
    IEnumerable<MedicalArticle> localQuery = sqlResults 
    .Where (article => wordCounter.Matches (article.Abstract).Count < 100);
