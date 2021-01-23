        @{
    
            var grid = new WebGrid(Model, canSort: true);
            grid.Pager(WebGridPagerModes.NextPrevious);
            var gridColumns = new List<WebGridColumn>
            {
                new WebGridColumn()
                {
                    ColumnName = "Id", Header = "Id", CanSort = true
                },
                new WebGridColumn()
                {
                    ColumnName = "Name", Header = "Name", CanSort = true
                }
            };
        }
    <div>
        @grid.GetHtml(tableStyle: "webGrid",
                headerStyle: "header",
                alternatingRowStyle: "alt",
                selectedRowStyle: "select",
                columns: grid.Columns(
                        gridColumns.ToArray()
                    )) 
