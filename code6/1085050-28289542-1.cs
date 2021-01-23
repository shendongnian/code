    @model IEnumerable<RequestDetailsViewModel>
    @using(Html.BeginForm())
    {
      @Html.EditorFor(m => m, new { StatusCodeList = (SelectList)ViewBag.StatusCodeList })
      <input type="submit" />
    }
