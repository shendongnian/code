    @*@model IEnumerable<ProjectDB.Models.Item>*@
    @*Change These Also as following*@
    @model PagedList.IPagedList<ProjectDB.Models.Item>
    @using PagedList.Mvc
    <table class="table">
    <tr>
        <th>
            Name
        </th>
        <th>
            ID
        </th>
        
        <th></th>
    </tr>
    @foreach (var item in Model) {
    <tr>
        <td>
            @Html.DisplayFor(modelItem => item.Name)
        </td>
        <td>
            @Html.DisplayFor(modelItem => item.ID)
        </td>
      
        <td>
            @Html.ActionLink("Edit", "Edit", new { id=item.Id }) |
            @Html.ActionLink("Details", "Details", new { id=item.Id }) |
            @Html.ActionLink("Delete", "Delete", new { id=item.Id })
        </td>
    </tr>
    }   
    </table>
    @*Pagination Code Starts*@
    <div class="pageCount">
        Page @(Model.PageCount < Model.PageNumber ? 0 : Model.PageNumber) of @Model.PageCount
    </div>
        @Html.PagedListPager(Model, pagePos => Url.Action("Index", new { pagePos }))
