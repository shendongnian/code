    ActionResult GetColumns(int object_id)
    {
         List<string> cols = new List<string>();
            using (var etm = new dbStudentsInfoEntities())
            {
              cols = etm.ExecuteStoreQuery<string>("SELECT name FROM sys.columns where object_id=" + object_id + " ORDER BY name").AsQueryable().ToList();
            }
    ViewBag.Output=cols ;
    }
