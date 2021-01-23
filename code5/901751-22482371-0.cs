    using (DataClassesDataContext db = new DataClassesDataContext())
    {
        var query = db.Surrenders.Where(s => s.Id.Equals(int.Parse(query_id.Value.ToString()))).Select(s => s).ToList();
        foreach (var item in query)
        {
             if (item != null)
             {
                 item.IsRead = false;
             }
        }
        db.SubmitChanges();
    }
