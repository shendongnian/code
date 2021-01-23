    @model IEnumerable<CategoryVM>
    @{
      ViewBag.Title = "Home Page";
    }
    <div class="container">
      @foreach (var category in Model)
      {
        <div class="row">
          <h5>@category.Name</h5>
          @foreach (var subCategory in category.SubCategories)
          {
            <div class="col-md-10">
              <div class="row">
                <h7>
                  // The following line in your view makes no sense
                  // <a href="/SubCategory/@subCat.Title">@subCat.Title</a>
                  // Assuming you have method: public ActionResult Details(string title) in SubCategoryController, then
                  @Html.ActionLink(subCategory.Title, "Details", "SubCategory", new { title = subCategory.Title }, null)
                </h7>
              </div>
              <div class="row">
                <p>@subCategory.Description</p>
              </div>
            </div>
            <div class="col-md-2">
              <p><span>@subCategory.ThreadCount</span><span>threads</span></p>
              <p><span>@subCategory.PostCount</span><span>posts</span></p>
            </div>
          }
        </div>
      }
    </div>
     
