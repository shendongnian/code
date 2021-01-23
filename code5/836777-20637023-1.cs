    public partial class LabeledComboBox : UserControl
    {
        public static readonly DependencyProperty ItemTemplateProperty = DependencyProperty.Register(
            "ItemTemplate",
            typeof(DataTemplate),
            typeof(LabeledComboBox),
            new PropertyMetadata(default(DataTemplate), ItemTemplateChanged));
        private static void ItemTemplateChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var labeledComboBox = (LabeledComboBox)d;
            labeledComboBox.LstItems.ItemTemplate = (DataTemplate)e.NewValue;
        }
        public DataTemplate ItemTemplate
        {
            get { return (DataTemplate)GetValue(ItemTemplateProperty); }
            set { SetValue(ItemTemplateProperty, value); }
        }
        // ...
    }
