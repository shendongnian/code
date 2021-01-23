    public class Entry
    {
        public string Key { get; set; }
        public bool KeyFocusable { get; set; }
    }
    public class BoolRow : Entry
    {
        public bool Value { get; set; }
        public BoolRow()
        {
            KeyFocusable = false;
        }
    }
    public class DoubleRow : Entry
    {
        public double Value { get; set; }
        public DoubleRow()
        {
            KeyFocusable = true;
        }
    }
    public class MyTemplateSelectorVal : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item is BoolRow)
            {
                return (DataTemplate)(container as FrameworkElement).FindResource("ValueTemplateBool");
            }
            else if (item is DoubleRow)
            {
                return (DataTemplate)(container as FrameworkElement).FindResource("ValueTemplateDouble");
            }
            else
            {
                return null;
            }
        }
    }
    public class MyTemplateSelectorKey : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item is BoolRow)
            {
                return (DataTemplate)(container as FrameworkElement).FindResource("KeyTemplate");
            }
            else if (item is DoubleRow)
            {
                return (DataTemplate)(container as FrameworkElement).FindResource("KeyTemplateEdit");
            }
            else
            {
                return null;
            }
        }
    }
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Entry> Rows = new ObservableCollection<Entry>();
        public MainWindow()
        {
            Rows.Add(new DoubleRow() { Key = "DoubleRow1", Value = 1.1 });      //Key editable
            Rows.Add(new DoubleRow() { Key = "DoubleRow2", Value = 3.1415 });   //Key editable
            Rows.Add(new BoolRow() {Key = "BoolRow", Value=true});              //Key not editable
            this.DataContext = Rows;
            InitializeComponent();
        }
        private void myDataGridMain_KeyDown(object sender, KeyEventArgs e)
        {
            DataGridCell cell = sender as DataGridCell;
            if (e.Key == Key.Enter)
            {
                var uiElement = e.OriginalSource as UIElement;
                if (e.Key == Key.Enter && uiElement != null)
                {
                    e.Handled = true;
                    uiElement.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
                }
            }
        }
    }
