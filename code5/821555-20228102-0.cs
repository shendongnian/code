     //establish initial query
     var queryBase = (from a in db.Jobs where a.StatusId == 7 select a);
    //instead of running the search against all of the entities, I first take the ones that are possible candidates, this is done through checking if they have any of the search terms under any of their columns. This is the one and only query that will be run against the database
    if (search.Count > 0)
            {
               
                nquery = nquery.Where(job => search.All(y => (job.Title.ToLower() + " " + job.FullDescription.ToLower() + " " + job.Company.Name.ToLower() + " " + job.NormalLocation.ToLower() + " " + job.MainCategory.Name.ToLower() + " " + job.JobType.Type.ToLower()).Contains(y))); //  + " " + job.Location.ToLower() + " " + job.MainCategory.Name.ToLower() + " " + job.JobType.Type.ToLower().Contains(y)));
            }
            //run the query and grab a list of baseJobs
            List<Job> baseJobs = nquery.ToList<Job>();
            //A list of SearchResult object (these object act as a container for job ids       and their search values
            List<SearchResult> baseResult = new List<SearchResult>();
            //from here on Jim's algorithm comes to play where it assigns points depending on where the search term is located and added to a list of id/value pair list
            foreach (var a in baseJobs)
            {
                foreach (var item in search)
                {
                    var itemLower = item.ToLower();
          
                    if (a.Company.Name.ToLower().Contains(itemLower))
                        baseResult.Add(new SearchResult { ID = a.ID, Value = 5 });
                    if (a.Title.ToLower().Contains(itemLower))
                        baseResult.Add(new SearchResult { ID = a.ID, Value = 3 });
                    if (a.FullDescription.ToLower().Contains(itemLower))
                        baseResult.Add(new SearchResult { ID = a.ID, Value = 2 });
                }
            }
            List<SearchResult> result = baseResult.GroupBy(x => x.ID).Select(p => new SearchResult() { ID = p.First().ID, Value = p.Sum(i => i.Value) }).OrderByDescending(a => a.Value).ToList<SearchResult>();
            //the data generated through the id/value pair list are then used to reorder the initial jobs.
            var NewQuery = (from id in result join jbs in baseJobs on id.ID equals jbs.ID select jbs).AsQueryable();
