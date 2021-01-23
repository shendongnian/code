    @foreach (var key in ViewData.ModelState.Keys)
    {
        var modelState = ViewData.ModelState[key];
        var property = ViewData.ModelMetadata.Properties.FirstOrDefault(p => p.PropertyName == key);
        if (property != null)
        {
            var displayName = property.DisplayName;
            foreach (var error in modelState.Errors)
            {
                <li>@displayName: @error.ErrorMessage</li>
            }
        }
        else
        {
            foreach (var error in modelState.Errors)
            {
                <li>@error.ErrorMessage</li>
            }
        }
    }
