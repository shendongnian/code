    /// <summary>
    /// Delete a particular filter set and its filters.
    /// </summary>
    /// <param name="filterSet">The filter set to be deleted.</param>
    public void DeleteFilterSet(FilterSet filterSet)
    {
      // First delete the child elements
      var filterRepository = new FilterRepository();
          
      foreach (var filter in filterRepository.GetFiltersBySets(filterSet))
      {
          var entry = _ctx.Entry(filter);
    
          if (entry.State==EntityState.Detached)
          {
              var set = _ctx.Set<Filter>();
              Filter attachedEntity = set.Local.SingleOrDefault(e => e.FilterId == filter.FilterId);
    
              if (attachedEntity!=null)
              {
                  var attachedEntry = _ctx.Entry(attachedEntity);
                  attachedEntry.State=EntityState.Deleted;
              }
              else
              {
                  entry.State = EntityState.Deleted;
              }
          }
           _ctx.SaveChanges();
      }
    
       // ...then delete the filter set
       _ctx.FilterSets.Remove(filterSet);
       _ctx.SaveChanges();
    }
