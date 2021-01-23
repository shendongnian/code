    foreach (var c in this.CABCodes) 
    {
      var detailList = new List<CABDetail>();
      foreach(var d in CAPDetails)
      {
        if (d.CABSquence == c.Sequence)
        {
          detailList.Add(d);
        }
      }
      c.Details = detailList;
    }
