    @(Html.Kendo().Grid<KendoUIMvcCim.Models.Customer>()
      .Name("grid")
      .DataSource(dataBinding => dataBinding.Ajax().Read(read => read.Action("Customers_Read", "Customer")))
      .Columns(columns =>
      {
          columns.Bound(customer => customer.Id);
          columns.Bound(customer => customer.Name);
          columns.Bound(customer => customer.Number);
          columns.Bound(customer => customer.AgentID);
          columns.Bound(customer => customer.Info);
          columns.Bound(customer => customer.Email);
          columns.Bound(customer => customer.StartTime);
          columns.Bound(customer => customer.EndTime);
          columns.Bound(customer => customer.Category);
      })
      .Pageable() 
      .Sortable() 
)
