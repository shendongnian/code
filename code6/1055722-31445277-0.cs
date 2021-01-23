    public static string GetCurrentPage()
            {
                var page = App.Navigation.NavigationStack.Last();
                return page.Title;
            }
