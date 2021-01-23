    @model IEnumerable<CategoryVM>
    <ul>
      @foreach(CategoryVM category in Model)
      {
        <li>
          <span>@Html.DisplayFor(m => category.Name)</span>
          <ul>
            @foreach(FileVM file in category.Files)
            {
              <li>
                @Html.ActionLink(file.Filename, "ShowFile", "Attachments", new { id = file.ID, collaborationId = category.ID }, new { target = "_blank" })
              </li>
            }
          </ul>
        <li>
      }
    <ul>
