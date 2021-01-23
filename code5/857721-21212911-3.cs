    model.PublisherList = context.Publishers.Select(x =>
        new SelectListItem()
        {
            Text = x.Name,
            Value = x.Id.ToString()
        }).ToList();
