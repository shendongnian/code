    @helper RenderGridBody()
    {
    if (!Model.ItemsToDisplay.Any())
    {
    <tr class="grid-empty-text">
        <td colspan="@Model.Columns.Count()">
            @Model.EmptyGridText
            
        </td>
    </tr>
    }
    else
    {
        Session["Items"]=Model.ItemsToDisplay;
        foreach (object item in Model.ItemsToDisplay)
        {
    <tr class="grid-row @Model.GetRowCssClasses(item)">
        @foreach (IGridColumn column in Model.Columns)
        {
            @column.CellRenderer.Render(column, column.GetCell(item))
        }
    </tr>
        }
    }
    } 
