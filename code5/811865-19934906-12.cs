    public int GetPage(int orderId, int sampleId, int itemsPerPage)
    {
        //protect against divide by zero
       if(itemsPerPage < 1)
          return 1;//or 0 if you want page index, or -1 if you want to flag this as invalid
       var result = context.Set<Sample>()
                    .Where(s => s.OrderId == orderId 
                                && s.Id <= sampleId)//this time include sampleId
                    //.OrderBy(s => s.ID)  edited after accepted OrderBy not necessary
                    .GroupBy(x => true)
                    .Select(group => new
                    {
                        MaxID = group.Max(s => s.Id),
                        Count = group.Count()
                    })
                    .Single();
      //Check the sample is actually in the result
      if(result.MaxID != sampleId)
          return 1;//or 0 if you want page index, or -1 if you want to flag this as invalid
      int index = result.Count - 1;
       //if you want the page index rather than the page number don't add 1
       return 1 + (index / itemsPerPage);
    }
