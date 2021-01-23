cs
    if(request.Sorts.Count == 1)
    {
        pRequest.SortMember = request.Sorts[0].Member;
        pRequest.SortDirection = (int)request.Sorts[0].SortDirection;
    }
    if (request.Filters.Count >= 1)
    {
        foreach(var item in request.Filters)
        {
            if(item is Kendo.Mvc.FilterDescriptor)
            {
                 var descriptor = (Kendo.Mvc.FilterDescriptor)item;
                 pRequest.Startdate = (DateTime)descriptor.ConvertedValue;
            }
        }                
    }
    else
    {
         var endDate = new TimeSpan(4000, 0, 0, 0, 0);
         pRequest.Startdate = DateTime.UtcNow - endDate;
    }
