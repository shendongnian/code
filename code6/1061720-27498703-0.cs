    using System;
    using Xamarin.Forms;
    namespace DataBinding_Lists
    {
    public class App
    {
        private static Page page;
        public static Page GetMainPage ()
        {   
            var listView = new ListView { RowHeight = 40 };
            listView.ItemsSource = new Person []
            {
                new Person { FirstName = "Abe", LastName = "Lincoln" },
                new Person { FirstName = "Groucho", LastName = "Marks" },
                new Person { FirstName = "Carl", LastName = "Marks" },
            };
    
            listView.ItemTemplate = new DataTemplate(typeof(TextCell));
            listView.ItemTemplate.SetBinding(TextCell.TextProperty, "FirstName");
            listView.ItemSelected += async (sender, e) => {
                await page.DisplayAlert ("Tapped!", e.SelectedItem + " was tapped.", "OK", "");
            };
    
            page = new ContentPage { 
                Content = new StackLayout
                {
                    Padding = new Thickness (5,20,5,5),
                    Spacing = 10,
                    Children = { listView }
                }
           
            };
            return page;
        }
    
    }
    }
