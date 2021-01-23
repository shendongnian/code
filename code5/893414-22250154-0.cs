     @(Html.Kendo().Grid<WebAnalise.Models.map_sel_fabr_prod>()
        .Name("grid")
        .Columns(columns =>
        {
          columns.Bound(p => p.tot11).Width(30).Title("Nov");
          columns.Bound(p => p.tot12).Width(30).Title("Dez");
          columns.Bound(c => c.Total).Title("Total")
          .ClientTemplate("#= kendo.format('{0:c}',Total) #")  
          .ClientFooterTemplate("<div>Grand Total: #= kendo.format('{0:c}',sum) #</div>");
       }
        .DataSource(dataSource => dataSource
              .Ajax()
              .Aggregates(aggregates =>
              {
                            
                 aggregates.Add(p => p.Total).Sum();                         
               })
              .PageSize(20)
              .Events(events => events.Error("error_handler"))
              .ServerOperation(false)                       
              .Events(e=>e.Edit("onEdit").Save("onSave"))
            )
