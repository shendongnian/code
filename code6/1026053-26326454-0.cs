    public partial class myUserControl : UserControl
    {
    public static myUserControl Instance {get; set;}
    public myUserControl()
    {
        InitializeComponent();
        Instance = this;
    }
    public string textBoxText
    {
        get { return textbox1.text; }
        set { textbox1.text = value; }
    }
