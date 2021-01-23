        .Columns(columns =>
        {
            columns.Bound(o => o.DisplayName).Width(200);        
            columns.Bound(o => o.Controller)
                .ClientTemplate("<a href='/<#= Controller #>' class='t-button'>View</a>")
                .Filterable(false)
                .Sortable(false);         
        })
