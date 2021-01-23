    List<Movie> movies = new List<Movie>() { new Movie() { MovieName = "Rambo" } };
    using (var writer = new XmlTextWriter("Web.sitemap", null))
    {
        var xmlElements = new XElement("siteMapNode",
            new XAttribute("title", "Movies"),
            movies.Select(i => new XElement
                ("siteMapNode",
                new XAttribute("title", i.MovieName),
                new XAttribute("url", string.Format("/Movie/{0}.html", i.MovieName))
                )));
        xmlElements.Save(writer);
    }
