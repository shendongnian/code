     protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            string Category = string.Empty;
            NavigationContext.QueryString.TryGetValue("category", out Category);
            if (this.DataContext is CategoryViewModel)
            {
                var vm = (CategoryViewModel)this.DataContext;
                vm.Images.Clear();
                JSONHelper.LoadFromJson().ContinueWith(t =>
                {
                    vm.CategoryName = Category;
                    var images = t.Result.Dirs.FirstOrDefault(p => p.DirName == Category).Files;
                    Dispatcher.BeginInvoke(() =>
                    {
                        foreach (var img in images)
                        {
                            vm.Images.Add(new Uri(string.Format("Data/{0}/{1}", Category, img), UriKind.Relative));
                        }
                    });
                });
            }
        }
