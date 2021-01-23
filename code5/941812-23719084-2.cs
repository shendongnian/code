    return View("Form", new PostsForm
        {
            Tags = (from item in TestBlog.Tags
                    select item).Select(tag => new
                    {
                        Id = tag.Id,
                        Name = tag.Name,
                        IsChecked = post.Tags.Any(t => t.Id == tag.Id)
                    }).
                    .AsEnumerable()
                    .Select(tag => new TagCheckBox
                    {
                        Id = tag.Id,
                        Name = tag.Name,
                        IsChecked = tag.IsChecked
                    })
                    .ToList()
        });
