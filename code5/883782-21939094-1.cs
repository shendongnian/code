    public UserControl1()
            {
                InitializeComponent();
        
                var parentWindow = new MainWindow();
        
                var myTestRadioButton = new RadioButton
                {
                    Name = "TestRadioButton",
                    Height = 31.5,
                    Width = 140,
                };
             //just add something like this  
            public  void AddChildControl(Window MyWindow)
           {
                  MyWindow.MyStackPanel.Children.Add(myTestRadioButton);
           }
    
         }
