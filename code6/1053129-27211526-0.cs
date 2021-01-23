     private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                dataGrid1.Items.Add(new Test { Test1 = "TestCell1", Test2 = "TestCell2", Test3 = "TestCell3" });
                dataGrid1.Items.Add(new Test { Test1 = "TestCell1", Test2 = "TestCell2", Test3 = "TestCell3" });
            }
        }
