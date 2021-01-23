    public ActionResult Convert(double? p1, String p2)
    {
      if (p1.HasValue)
      {
        var d = p1.Value;
        // Do the equivalent of Convert(d, p2)
      }
      else
      {
        // Handle the null p1.
      }
    }
