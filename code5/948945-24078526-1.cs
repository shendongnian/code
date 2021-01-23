    // Controllers/TaskController.cs
    public virtual ActionResult Export () {
        var tasks = repository.GetAllTasks();
			
        Response.AddHeader("Content-Disposition", "attachment; filename=Tasks.xls");
        Response.ContentType = "application/ms-excel";
        return PartialView("Export", tasks);
    }
    // /Views/Task/Export.cshtml
    @model IEnumerable<OpuzEleven.Models.Task>
    @using GridMvc.Html;
    @(Html.Grid(Model, "_GridExcel")
        .Named("TaskGrid")
        .AutoGenerateColumns()
        .Columns(columns => columns.Add(c => c.UserProfile.FullName).Titled("Created by"))
        .Sortable(true)
        .Filterable(true))
    // /Shared/_GridExcel.cshtml
    @using GridMvc.Columns
    @model GridMvc.IGrid
    
    @if (Model == null) { return; }
    @if (Model.RenderOptions.RenderRowsOnly) {
      @RenderGridBody();
    } else {
      <div class="grid-mvc" data-lang="@Model.Language" data-gridname="@Model.RenderOptions.GridName" data-selectable="@Model.RenderOptions.Selectable.ToString().ToLower()" data-multiplefilters="@Model.RenderOptions.AllowMultipleFilters.ToString().ToLower()">
        <div class="grid-wrap">
          <table class="table table-striped grid-table">
            @* Draw grid header *@
            <thead>
              @RenderGridHeader()
            </thead>
            <tbody>
              @RenderGridBody()
            </tbody>
          </table>
        </div>
      </div>
    }
    
    @helper RenderGridBody () {
      if (!Model.ItemsToDisplay.Any()) {
        <tr class="grid-empty-text">
          <td colspan="@Model.Columns.Count()">
            @Model.EmptyGridText
          </td>
        </tr>
      } else {
        foreach (object item in Model.ItemsToDisplay) {
          <tr class="grid-row @Model.GetRowCssClasses(item)">
            @foreach (GridMvc.Columns.IGridColumn column in Model.Columns) {
              @column.CellRenderer.Render(column, column.GetCell(item))
            }
          </tr>
        }
      }
    }
    
    @helper RenderGridHeader () {
      <tr>
        @foreach (GridMvc.Columns.IGridColumn column in Model.Columns) {
          <th>@column.Title</th>
        }
      </tr>
    }
