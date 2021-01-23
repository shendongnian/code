    XNamespace foobar = "http://www.april-technologies.com";
    var prix  = docxx.Descendants(foobar + "CotisationMensuelle").Select(x => new { CotisationMensuelle =(string)x}).ToList();
    var newPrix = new List<string>();
    foreach (var s in prix)
    {
    	var s1 = s.CotisationMensuelle.Substring(0, s.CotisationMensuelle.Length - 2);
    	var s2 = s.CotisationMensuelle.Substring(s.CotisationMensuelle.Length - 2);
    	newPrix.Add(s1);
    	newPrix.Add(s2);
    }
    rpMyRepeater1.DataSource = newPrix.Select(x => new {CotisationMensuelle = x}).ToList();
    rpMyRepeater1.DataBind();
