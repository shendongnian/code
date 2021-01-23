    StackPanel panel = new StackPanel();
    Label label1 = new Label();
    Label label2 = new Label();
    panel.Children.Add(label1);
    panel.Children.Add(label2);
    var yourVM = GetYourCurrentViewModelWithSelectedGameProperty();
    // Set data context
    Binding binding = new Binding("SelectedGame");
    binding.Source = yourVM;
    panel.SetBinding(FrameworkElement.DataContextProperty, binding);
    binding = new Binding("HomeScoreText");
    binding.Source = panel.DataContext;
    label1.SetBinding(ContentControl.ContentProperty, binding);
    binding = new Binding("AwayScoreText");
    binding.Source = panel.DataContext;
    label2.SetBinding(ContentControl.ContentProperty, binding);
