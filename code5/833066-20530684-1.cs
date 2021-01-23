    foreach (item in list)
    { 
       Button newBtn = new Button();
       newBtn.Content = "Button Text";
       newBtn.Tag = item.Tag;
       newBtn.Name = item.Name;
       newBtn.Click += (sender, e) => {
         NavigationService.Navigate(new Uri("/DetailPage.xaml?selectedItem=" + newBtn.Tag, UriKind.Relative));
       };
    }
