      public partial class TextBoxControl : UserControl
      {
        public TextBoxControl()
        {
          InitializeComponent();
          this.DataContextChanged += TextBoxControl_DataContextChanged;
        }
    
        void TextBoxControl_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
          //Set breakpoint here...
        }
      }
