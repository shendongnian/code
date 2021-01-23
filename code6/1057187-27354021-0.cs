    private void test_KeyDown(object sender, KeyEventArgs e)
    {
        if(e.Key == System.Windows.Input.Key.SomeKey)
           command.Text = "Y";
    }
    private void test_KeyUp(object sender, KeyEventArgs e)
    {
        if(e.Key == System.Windows.Inpput.Key.SomeKey)
           command.Text = "N";
    }
