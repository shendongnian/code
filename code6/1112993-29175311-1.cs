    public void DoSomething()
    {
      using(var vptm = new ViewablePipeTypeModel())
      {
          var qry = from pt in vptm
              select new
              {
                Id = pt.Id,
                KpM = pt.KilosPerMeter()
              };
      }
    }
