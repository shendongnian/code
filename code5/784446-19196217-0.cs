    @model IEnumerable<AOSExpress.Models.SearchModel>
    <div>
    @{
        // Notice the removal of the @ symbol
        var grid = new WebGrid(Model);        
    }
    @grid.GetHtml()
    </div>
