    public partial class MainWindow : Window
        {
            int num = 0;
            public MainWindow()
            {
                InitializeComponent();
            }
    
            void btn1_Click(object sender, RoutedEventArgs e)
            {
                throw new NotImplementedException();
            }
    
            void btn2_Click(object sender, RoutedEventArgs e)
            {
                throw new NotImplementedException();
            }
    
            private void btn_Remove_Click(object sender, RoutedEventArgs e)
            {
                try
                {
                    Grid_Grid.RowDefinitions.RemoveAt(Grid_Grid.RowDefinitions.Count - 1);
                    Grid_Grid.Children.RemoveAt(Grid_Grid.Children.Count - 1);
                    num--;
                }
                catch { }
            }
    
            private void btn_Add_Click(object sender, RoutedEventArgs e)
            {
                StackPanel stack = new StackPanel();
                DockPanel dock = new DockPanel();
                Label lbl = new Label();
                Button btn1 = new Button();
                Button btn2 = new Button();
                TextBox txt1 = new TextBox();
    
                stack.Children.Add(dock);
                stack.Children.Add(txt1);
                dock.Children.Add(lbl);
                dock.Children.Add(btn2);
                dock.Children.Add(btn1);
    
                #region StackPanel Properties
                stack.Background = Brushes.LightGray;
                #endregion
    
                #region DockPanel Content Properties
                lbl.Content = "Label " + (num + 1).ToString();
                lbl.Height = 32;
                lbl.Width = 100;
                lbl.FontSize = 12;
                lbl.SetValue(DockPanel.DockProperty, Dock.Left);
                lbl.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
    
                btn1.Content = "Butten 1";
                btn1.Height = 32;
                btn1.Width = 100;
                btn1.FontSize = 12;
                btn1.HorizontalAlignment = System.Windows.HorizontalAlignment.Right;
                btn1.SetValue(DockPanel.DockProperty, Dock.Right);
                btn1.Click += new RoutedEventHandler(btn1_Click);
    
                btn2.Content = "Butten 2";
                btn2.Height = 32;
                btn2.Width = 100;
                btn2.FontSize = 12;
                btn2.HorizontalAlignment = System.Windows.HorizontalAlignment.Right;
                btn2.SetValue(DockPanel.DockProperty, Dock.Right);
                btn2.Click += new RoutedEventHandler(btn2_Click);
                #endregion
    
                #region TextBox Properties
                txt1.Text = "Text " + (num + 1).ToString();
                txt1.Height = 32;
                txt1.Width = double.NaN;
                txt1.FontSize = 12;
                txt1.Padding = new Thickness(0, 7, 0, 7);
                #endregion
    
                Grid_Grid.RowDefinitions.Add(new RowDefinition());
                Grid_Grid.RowDefinitions[num].Height = new GridLength(66, GridUnitType.Pixel);
                Grid_Grid.Children.Add(stack);
                stack.SetValue(Grid.RowProperty, num);
                num++;
            }
        }
