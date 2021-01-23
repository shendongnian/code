    public JsonResult GetSeries(int id)
    {
      var data = db.Series.Where(v => v.AuthorID == id).Select(s => new
      {
        Value = s.SeriesID;
        Text = s.SeriesName;
      }
        return Json(data));
    }
