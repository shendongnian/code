    var query =
            from pl in Context.PostsLocalized
			where pl.Culture == culture
			let p = p1.Post
			let categories = p.Categories
			let localizedCategories = categories.SelectMany(cat => cat.CategoriesLocalized).Where(cl => cl.Culture == culture)
            let galleries = p.Galleries
			let galleryItems = galleries.SelectMany(gal => gal.GalleryItems)
			let cl = localizedCategories.FirstOrDefault() // only one or zero of these i assume?
			select new PostLocalizedOutput
            {
                PostId = p1.PostId,
                CategoryId = cl.CategoryId, 
                Title = pl.Title,
                FormattedCategoryName = cl.FormattedCategoryName,
                PostContent = pl.PostContent,
                PostType = pl.Post.PostType,
                IOrder = pl.Post.IOrder,
                Tags = pl.Tags,
                PublishDate = pl.Post.PublishDate,
                ViewCount = pl.Post.ViewCount,
                ShowInHomePageSlider = pl.Post.ShowInHomePageSlider,
                AllowComments = pl.Post.AllowComments,
                Image = pl.Post.Image,
                IsArchived = pl.Post.IsArchived,
                IsDraft = pl.Post.IsDraft,
                IsPublished = pl.Post.IsPublished,
				
                GalleryItems = galleryItems.Select(gi => new GalleryItemOutput
                {
                    FileName = gi.FileName,
                    GalleryId = gi.GalleryId,
                    Id = gi.Id,
                    Notes = gi.Notes,
                    Title = gi.Title
                    })
    // might need a .ToList() here on those GalleryItems
    
     (around here i feel like i should foreach something or what?)
                };
