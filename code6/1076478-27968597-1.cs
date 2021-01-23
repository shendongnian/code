    public partial class Window7 : Window
    {
        public Window7()
        {
            InitializeComponent();            
            this.DataContext= new CaretViewModel();
        }
    }
    public class CaretViewModel : INotifyPropertyChanged
    {
        private int myVar;
        public int Caret
        {
            get { return myVar; }
            set { myVar = value; Notify("Caret"); }
        }
        public CaretViewModel()
        {
            Caret = 5;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        void Notify(string property)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
    public static class TextBoxHelper
    {
        public static int GetCaret(DependencyObject obj)
        {
            return (int)obj.GetValue(CaretProperty);
        }
        public static void SetCaret(DependencyObject obj, int value)
        {
            obj.SetValue(CaretProperty, value);
        }
        
        public static readonly DependencyProperty CaretProperty =
            DependencyProperty.RegisterAttached(
                "Caret",
                typeof(int),
                typeof(TextBoxHelper),
                new FrameworkPropertyMetadata(0, CaretChanged));
        private static void CaretChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            TextBox tb = obj as TextBox;
            if (tb != null)
            {
                int newValue = (int)e.NewValue;
                
                if (newValue != tb.CaretIndex)
                {                    
                    tb.CaretIndex = (int)newValue;
                }
            }
        }
    }
