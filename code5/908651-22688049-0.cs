    @if (!string.IsNullOrEmpty(@ViewData.ModelMetadata.Properties.First(x => x.PropertyName == "SiteAndJobDetails").Properties.SingleOrDefault(x => x.PropertyName == Model.SiteAndJobDetails.GetType().GetProperties()[i].Name).DisplayName))
    {
        @ViewData.ModelMetadata.Properties.First(x => x.PropertyName == "SiteAndJobDetails").Properties.SingleOrDefault(x => x.PropertyName == Model.SiteAndJobDetails.GetType().GetProperties()[i].Name).DisplayName
    }
    else
    {
        @Model.SiteAndJobDetails.GetType().GetProperties()[i].Name
    }
