    protected override void Dispose(bool disposing)
    {
      if (disposing && db != null)
        db.Dispose();
      base.Dispose(disposing);
    }
