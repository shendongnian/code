        public static Page GetMainPage()
        {   
            var button = new Button
                {
                    Text = "Click to display web page",
                    VerticalOptions = LayoutOptions.CenterAndExpand,
                    HorizontalOptions = LayoutOptions.CenterAndExpand,
                };
            var page = new ContentPage
            {
                Content = button
            };
            button.Clicked += async (s, e) =>
                {
                    try
                    {
                        var webPage = await new HttpClient().GetStringAsync(new Uri("http://www.google.se"));
                        await page.DisplayAlert("alert", webPage, "ok", "cancel");
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine(ex.Message);
                    }
                };
            return page;
        }
