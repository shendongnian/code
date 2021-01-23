    private void btnAddTitle_Click(object sender, RoutedEventArgs e)
    {
        CurrentSortItem++;
        SortItems.Add(CurrentSortItem);
        StackPanel outerSp = new StackPanel() { Orientation = Orientation.Vertical };
        StackPanel sp = new StackPanel() { Orientation = Orientation.Horizontal };
        gp = new GroupBox();
        ComboBox y = new ComboBox();
        y.Name = "Combo" + CurrentSortItem;
        y.SelectedItem = CurrentSortItem;
        y.Height = 25;
        y.Width = 45;
        y.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
        y.Margin = new Thickness(20, 15, 0, 0);
        foreach (int item in SortItems)
        {
            y.Items.Add(item);
        }
        TextBox x = new TextBox();
        x.Name = "Title" + CurrentSortItem;
        x.Text = "Title...";
        x.FontWeight = FontWeights.Bold;
        x.FontStyle = FontStyles.Italic;
        x.TextWrapping = TextWrapping.Wrap;
        x.Height = 25;
        x.Width = 200;
        x.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
        x.Margin = new Thickness(12, 15, 0, 0);
        sp.Children.Add(y);
        sp.Children.Add(x);
        
        outerSp.Children.Add(sp);
        gp.Content = outerSp;
        spStandard.Children.Add(gp);
    }
    private void ViewQuestions(StackPanel sp)
    {
    var stackPanel=gp.Content as StackPanel;
    if(stackPanel!=null)
    {
        stackPanel.Children.Add(sp);
     }
    else
       gp.Content=sp;
    }
    List<int> SortItems1 = new List<int>();
    int CurrentSortItem1 = 0;
    int Count = 0;
    private void btnQuestion_Click(object sender, RoutedEventArgs e)
    {
        if (SortItems.Count == 0)
        {
            MessageBox.Show("You must add a title before adding a question", "ERROR", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        else
        {
            Count++;
            CurrentSortItem1++;
            SortItems1.Add(CurrentSortItem1);
            
                ComboBox y = new ComboBox();
                y.Name = "Combo" + CurrentSortItem1;
                y.SelectedItem = CurrentSortItem1;
                y.Height = 25;
                y.Width = 45;
                y.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
                y.Margin = new Thickness(20, 15, 0, 0);
                foreach (int item in SortItems1)
                {
                    y.Items.Add(item);
                }
                TextBox x = new TextBox();
                x.Name = "Question" + CurrentSortItem1;
                x.Text = "Question...";
                x.FontStyle = FontStyles.Italic;
                x.TextWrapping = TextWrapping.Wrap;
                x.Height = 25;
                x.Width = 500;
                x.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
                x.AcceptsReturn = true;
                x.Margin = new Thickness(100, 15, 0, 0);
                TextBox z = new TextBox();
                z.Name = "Points" + CurrentSortItem;
                z.FontWeight = FontWeights.Bold;
                z.Height = 25;
                z.Width = 45;
                z.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
                z.Margin = new Thickness(250, 15, 0, 0);
                sp.Children.Add(y);
                sp.Children.Add(x);
                sp.Children.Add(z);
                outerSp.Children.Add(sp);
                ViewQuestions(sp);
    }
