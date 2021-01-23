    public partial class ButtonGrid : UserControl
        {
            private int rows, cols;
            private Button[] buttons;
            public ButtonGrid()
            {
                InitializeComponent();
    
                cols = 4;
                rows = 8;
                buttons = new Button[cols * rows];
                Button button;
                for (int i = 0; i < cols; i++)
                {
                    for (int j = 0; j < rows; j++)
                    {
                        // Make the button, set its place on the grid, set the necessary properties, give it OnClick, then add it to the grid
                        button = new Button();
                        button.SetValue(Grid.ColumnProperty, i);
                        button.SetValue(Grid.RowProperty, j);
    
                        button.Name = "Button" + (j + (rows * (i))).ToString();
                        button.Content = j + (rows * (i));
                        button.IsEnabled = false;
    
                        button.Click += OnClick;
    
                        buttons[j + (rows * (i))] = button;
                        PART_Grid.Children.Add(button);
                    }
                }
                buttons[12].IsEnabled = true;
            }
    
            private void OnClick(object sender, RoutedEventArgs e)
            {
                int index;
                Button button = sender as Button;
                // Determine which button was pressed by finding the index of the button that called this from the button name
                if (button.Name.Length == 7)
                {
                    index = Int32.Parse(button.Name.Substring(6, 1));
                }
                else
                {
                    index = Int32.Parse(button.Name.Substring(6, 2));
                }
    
                // Make sure the buttons that are being affected are within bounds
                if ((index - 1) >= 0)
                {
                    buttons[index - 1].IsEnabled = true;
                }
    
                if ((index - rows) >= 0)
                {
                    buttons[index - rows].IsEnabled = true;
                }
    
                if ((index + 1) <= (cols * rows - 1))
                {
                    buttons[index + 1].IsEnabled = true;
                }
    
                if ((index + rows) <= (cols * rows - 1))
                {
                    buttons[index + rows].IsEnabled = true;
                }
            }
        }
