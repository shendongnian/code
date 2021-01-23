    public MainPage()
            {
                this.InitializeComponent();
                AddControl();
            }
    
    
    
            private void AddControl()
            {
                TextBox txtcontent = new TextBox();
                txtcontent.HorizontalAlignment = Windows.UI.Xaml.HorizontalAlignment.Stretch;
                txtcontent.SetValue(Grid.ColumnProperty, 1);
                txtcontent.SetValue(Grid.RowProperty, 0);
                txtcontent.Width = 150;
                txtcontent.FontSize = 20;
                txtcontent.TextWrapping = TextWrapping.Wrap;
                txtcontent.Margin = new Thickness(10);
                txtcontent.AddHandler(TappedEvent, new TappedEventHandler(txtcontent_Tapped), true);
                //txtcontent.Foreground = new Solid
                //txtcontent.BorderBrush = App.scbAccTechGrayLight;
                //txtcontent.Background = App.scbAccTechGreenLight;
                this.LayoutRoot.Children.Add(txtcontent);
            }
    
         
            void txtcontent_Tapped(object sender, TappedRoutedEventArgs e)
            {
                System.Diagnostics.Debug.WriteLine("Tested by WmDev!!");
            }
