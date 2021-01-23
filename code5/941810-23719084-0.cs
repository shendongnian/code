        Tags = (from item in TestBlog.Tags
                select item).Select(tag => new
                {
                    Id = tag.Id,
                    Name = tag.Name,
                    IsChecked = post.Tags.Contains(tag)
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
