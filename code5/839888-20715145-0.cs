    @for (int i = 0; i < Model.Sites.Count; i++)
    {
        <tr>
            <td>
                @Html.DisplayFor(modelItem => Model.Sites[i].Name)
            </td>
            <td>@Html.EditButton("Edit", Url.Action("Edit", new { siteID = Model.Sites[i].SiteID }), new ButtonRequirement { ExtraClasses = "btn-xs" })</td>
            <td>@Html.ViewButton("View", Url.Action("Details", new { siteID = Model.Sites[i].SiteID }), new ButtonRequirement { ExtraClasses = "btn-xs" })</td>
            <td>
                @using (Html.BeginForm("Delete", "Site"))
                {
                    @Html.Hidden("siteID", Model.Sites[i].SiteID)
                    @Html.DeleteButton("Delete", new ButtonRequirement { ExtraClasses = "btn-xs" })
                }
            </td>
        </tr>
    }
