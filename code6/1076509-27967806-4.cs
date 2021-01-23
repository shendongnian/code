    var query = _Context.vwArticles
        .Where(x => a.ArticleTitle == modelSelectedArticleTitle &&
                    a.shortName == regionShortName &&
                    a.Country == modelSelectedCountryshortName);
    if (myParameter > 0) {
        query = query.Where(x => x.Table1Id == myParameter);
    }
    return query.ToList();
