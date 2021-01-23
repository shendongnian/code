      MenuFlyout m = new MenuFlyout();
      Style s = new Windows.UI.Xaml.Style { TargetType = typeof(MenuFlyoutPresenter) };
      s.Setters.Add(new Setter(BackgroundProperty,new SolidColorBrush(Colors.Blue)));
      MenuFlyoutItem mn = new MenuFlyoutItem();
      m.MenuFlyoutPresenterStyle = s;
      m.Items.Add(mn);
   
     
