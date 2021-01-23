    public static readonly DependencyProperty IngredientNameProperty
        = DependencyProperty.Register(
            "IngredientName",
            typeof(string),
            typeof(MyUserControl),
            new PropertyMetadata(HandleIngredientNameChanged));
    public string IngredientName
    {
        get { return (string)GetValue(IngredientNameProperty); }
        set { SetValue(IngredientNameProperty, value); }
    }
    private static void HandleIngredientNameChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        var control = (MyUserControl) d;
        control.txt_ingredientName.Text = (string) e.NewValue;
    }
