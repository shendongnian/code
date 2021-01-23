    @foreach (var item in Model)
    {
      <span>@item.EmailAddress</span>
      @using (Html.BeginForm("ProcessEmail"))
      {
        @Html.HiddenFor(m => item.EmailAddress , new { id = "" }) // remove the id attribute to prevent invalid html
        <button type="submit">Generate code</button>
      }
    }
