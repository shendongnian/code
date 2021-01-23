            SearchFilter.SearchFilterCollection coll = new SearchFilter.SearchFilterCollection(LogicalOperator.And);            
            SearchFilter subjectFilter = new SearchFilter.ContainsSubstring(AppointmentSchema.Subject, "test");
            SearchFilter dateFilter = new SearchFilter.IsGreaterThanOrEqualTo(AppointmentSchema.Start, DateTime.Today);
            coll.Add(subjectFilter);
            coll.Add(dateFilter);
            FindItemsResults<Item> findResults = svc().FindItems(fId, coll, view);
