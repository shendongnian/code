    @foreach (var item in Model)
    {
      <span>@item.EmailAddress</span>
      @using (Html.BeginForm("ProcessEmail", new { emailAddress = item.EmailAddress }))
      {
        <button type="submit">Generate code</button>
      }
    }
