    private readonly ViewModel _model;
    public CustomCell (ViewModel model)
    {
        _model = model; <--- Your DI foo
        BindingContext = model; <---
        button = new Button ();
        button.Text = "Add";
        button.VerticalOptions = LayoutOptions.Center;
        button.Clicked += (sender, args) => _model.DoSomething(); <---- Your action
        var nameLabel = new Label ();
        nameLabel.SetBinding (Label.TextProperty, "name");
        nameLabel.HorizontalOptions = LayoutOptions.FillAndExpand;
        nameLabel.VerticalOptions = LayoutOptions.Center;
        var viewLayout = new StackLayout () {
            Padding = new Thickness (10, 0, 10, 0),
            Orientation = StackOrientation.Horizontal,
            Children = { nameLabel, button }
        };
        View = viewLayout;
    }
