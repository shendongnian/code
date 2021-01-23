    public partial class TopSection : UserControl
    { 
     public class SampleViewModel { get; set; }
   
     public TopSection()
     {
        this.InitializeComponent();
        this.DataContext = new SampleViewModel();
     }
     public static readonly DependencyProperty SubHeaderTextProperty =
        DependencyProperty.Register("SubHeaderText", typeof(string), typeof(TopSection));
     public string SubHeaderText
     {
        get { return (string)GetValue(SubHeaderTextProperty); }
        set { SetValue(SubHeaderTextProperty, value); }
     } 
    }
