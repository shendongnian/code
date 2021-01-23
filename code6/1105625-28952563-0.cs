        var query = context.Fields
            .Where( 
                x => x.DeletedAt == null 
            );
        // Apply search
        if( searchCriteria != null )
        {
            if( searchCriteria.SearchTerm != "" )
            {
                query = query.Where(
                    x => x.Location.Contains( searchCriteria.SearchTerm )
                );
            }
        }
        return query;
