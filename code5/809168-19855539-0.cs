    <%: Html.Kendo().Grid<CustomerTest.Models.ProductViewModel>()
       .Name("grid")
          .DataSource(dataSource => dataSource
              .Ajax()
              .Model(model => model.Id(p => p.CustomerID))
              .Read(read => read.Action("Printc", "Home") 
              )
          )
          .Columns(columns =>
          {
              columns.Bound(product => product.CustomerID);
              columns.Bound(product => product.CustomerFName);
              columns.Bound(product => product.CustomerLName);
          })
          .Pageable()
          .Sortable()
    %>
