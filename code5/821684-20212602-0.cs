    private void btn_Click(object sender, RoutedEventArgs e)
            {
                Button btn = sender as Button;
                StackPanel stkButtonParent = btn.Parent as StackPanel;
                StackPanel stkCover = stkButtonParent.Parent as StackPanel;
                StackPanel newRow = NewRow();
                stkCover.Children.Add(newRow);
            }
    
            private StackPanel NewRow() {
                StackPanel stk = new StackPanel();
                stk.Orientation = Orientation.Horizontal;
                Label lbl = new Label();
                lbl.Foreground = Brushes.Red; // some attribute
                TextBox txt = new TextBox();
                txt.Background = Brushes.Transparent; // some attribute
                Button btn = new Button();
                btn.Content = "Add new row";
                btn.Click += btn_Click;
                stk.Children.Add(lbl);
                stk.Children.Add(txt);
                stk.Children.Add(btn);
                return stk;
            }
