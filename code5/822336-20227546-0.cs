    @Html.DevExpress().NavBar(
                settings =>
                {
                    settings.Name = "navBarSettings";
                    settings.Groups.Add(group => {
                        group.Text = "Miscellaneous Properties";
                        group.SetContentTemplateContent(c =>
                            {
                                Html.RenderPartial("MiscellaneousPropertiesPartialView");
                            }
                        );
                    });
    
                    settings.Groups.Add(group =>
                    {
                        group.Text = "Other Properties";
                    });
                    
                }).GetHtml()     
        }
