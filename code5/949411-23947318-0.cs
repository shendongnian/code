       string formattedId=string.Empty;
       string OriginalStr=string.Empty; 
       public MainWindow()
       {
          this.InitializeComponent();
          this.idPattern = @"^(\d{3})(\d{3})(\d{3})";
          this.idReplacement = "$1-$2+$3";
       }
    
       private void UIElement_OnLostFocus(object sender, RoutedEventArgs e)
       {
           OriginalStr=Convert.ToString(textBox.Text);
           string formatted = Regex.Replace(textBox.Text, this.idPattern , this.idReplacement );
           formattedId = formatted;
       }
