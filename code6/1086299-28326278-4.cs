    var asset = db.Assets.Find(id);
    if (asset == null)
    {
        return new HttpNotFoundResult();
    }
    var model = new AssetViewModel
    {
        Title = asset.Title,
        Description = asset.Description,
        // etc.
        SelectedCategoryIds = asset.Categories.Select(m => m.Id).ToList()
    };
