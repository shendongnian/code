    private static List<DomainModel> MapEditViewModelToDomainModels(EditViewModel viewModel)
    {
        var settings = new List<DomainModel>();
        var stringPropertyNamesAndValues = viewModel.GetType().GetProperties().Where(p => p.CanRead).Select(p => new {Name = p.Name, Value = p.GetValue(viewModel, null)});
        foreach (var pair in stringPropertyNamesAndValues)
        {
            var model= new DomainModel
            {
                Key = pair.Name,
                Value = pair.Value.ToString()
            };
            settings.Add(model);
        }
        return settings;
    }
