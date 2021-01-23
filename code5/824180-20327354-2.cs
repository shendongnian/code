    .DataKeys(x =>
                    {
                        x.Add(y => y.Id).RouteKey("Id");
                    })
     var nop_gModel = new PictureModel.myPictureModel()
                    {
                        Id = x.Id,//Changed as you are getting picture by Id
                        PictureUrl = _pictureService.GetPictureUrl(x.PictureID),
                        DisplayOrder = x.OrderNumber,
                        Description = x.Description
                    };
    var galleryPicture = _galleryItemService.GetGalleryPictureById(model.Id);
