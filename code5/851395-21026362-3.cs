    private void Go_Button_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            ExcelOperations temp = new ExcelOperations();
            temp.Begin();
        }
        catch
        {
            // close the program
        }
    }
