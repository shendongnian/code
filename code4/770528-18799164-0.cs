    var json = "{ \"JBS\" : { \"name\" : \"Jobsite\" }, \"LNK\" : { \"name\" : \"Linked IN\" }, \"MUK\" : { \"name\" : \"Monster UK\" } }";
    var result = new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<Dictionary<string, JobSite>>(json);
    var jobsites = new List<JobSite>(result.Count);
    foreach (var pair in result)
    {
        var jobsite = pair.Value;
        jobsite.Short = pair.Key;
        jobsites.Add(jobsite);
    }
