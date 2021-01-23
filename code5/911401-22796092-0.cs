    public GenericDialogBox(string MainLabelContent, string WindowTitle, string TextboxDefaultText, ValidationRule rule)
        {
          this.DataContext = this;
          Text = "";
          if (rule != null)
          {
            TextBoxValidationRule = rule;
          }
          InitializeComponent();
          MainLabel.Content = MainLabelContent;
          Title = WindowTitle;
    
          Binding binding = BindingOperations.GetBinding(MainTextBox, TextBox.TextProperty);
          binding.ValidationRules.Add(rule);
            
    
          MainTextBox.SelectAll();
          MainTextBox.Focus();
        }
