    public MainWindow()
    {
        InitializeComponent();
        this.DataContext = this;
        lbNoBinding.SelectedValuePath = "StrMix";
        lbNoBinding.DisplayMemberPath = "StrMix";
    }
    public class MixedType
    {
        public string StrMix { get { return "strMix"; } }
        public bool BoolMix { get { return true; } }
    }
    private List<MixedType> mixedTypes = new List<MixedType>() { new MixedType(), new MixedType() };
    public List<MixedType> MixedTypes
    {
        get { return mixedTypes; }
    }
    
    private void btnClick(object sender, RoutedEventArgs e)
    {
        try
        {                
            lbNoBinding.SelectedValuePath = "BoolMix";
            lbNoBinding.DisplayMemberPath = "BoolMix";
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(ex.Message);
        }
    }
