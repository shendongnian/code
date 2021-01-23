    @(Html.Kendo().Grid<OMSWeb.Models.OrderGridViewModel>()
        .Name("grid")
        .HtmlAttributes(new { style = "width:115%;font-size:10px;line-height:2em" })
        .Columns(columns =>
        {
          //columns
        })
            .Selectable(s => s.Mode(GridSelectionMode.Single).Type(GridSelectionType.Cell))              
            .Pageable() // Enable paging
            .Sortable() // Enable sorting
            .ClientDetailTemplateId("OrderDetailsAll")
            .DataSource(dataSource => dataSource
            .Ajax()
            .PageSize(5)
            .Read(read => read.Action("Get", "Order"))
    
            ))
            
    <script id="OrderDetailsAll" type="text/kendo-tmpl">
        @(Html.Kendo().Grid<OMSWeb.Models.OrderDetailAllViewModel>()
            .Name("grid2_#=OpportunityId#") //opprtunityId == row to detail off of 
            .Editable(editable => editable.Mode(GridEditMode.InCell))  
            .Columns(columns =>
            {
                //columns
        
            })   
            .DataSource(dataSource => dataSource
                .Ajax()
                .Read(read => read.Action("GetDetailsAll", "Order", new {  opportunityId = "#=OpportunityId#" })) //get selected rows details
                          .Model(model => 
                   {
                       model.Id (z => z.OrderDetailId);                  
                   })      
            )   
            .ToClientTemplate())
    
    </script>
