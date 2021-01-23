    delegate void Callback<in T>(T t);
    public Form1()
    {
        InitializeComponent();
        Callback<Control> showText = control => MessageBox.Show(control.Text);
        var button = new Button();
        AddButtonClickCallback(button, showText);
        var label = new Label();
        AddLabelClickCallback(label, showText);
    }
    static void AddButtonClickCallback(Button button, Callback<Button> callback)
    {
        button.Click += delegate { callback(button); };
    }
    static void AddLabelClickCallback(Label label, Callback<Label> callback)
    {
        label.Click += delegate { callback(label); };
    }
