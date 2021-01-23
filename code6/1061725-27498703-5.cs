    using System;
    using Xamarin.Forms;
    namespace DataBinding_Lists
    {
    public class PeoplePage : Page
    {
        public PeoplePage()
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
                await DisplayAlert ("Tapped!", e.SelectedItem + " was tapped.", "OK", "");
            };
    
            Content = new ContentPage { 
                Content = new StackLayout
                {
                    Padding = new Thickness (5,20,5,5),
                    Spacing = 10,
                    Children = { listView }
                }
           
            };
        }
    
    }
    }
