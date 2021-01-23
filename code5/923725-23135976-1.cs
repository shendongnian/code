    public partial class TopSection : UserControl
    { 
     public class MyModel { get; set; }
   
     public TopSection()
     {
        MyModel = new MyModel() { SubHeaderText = "Sample" };
        this.InitializeComponent();
     }
     public static readonly DependencyProperty SubHeaderTextProperty =
        DependencyProperty.Register("SubHeaderText", typeof(string), typeof(TopSection));
     public string SubHeaderText
     {
        get { return (string)GetValue(SubHeaderTextProperty); }
        set { SetValue(SubHeaderTextProperty, value); }
     } 
    }
