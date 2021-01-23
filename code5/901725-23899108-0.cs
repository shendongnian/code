    private void Start_Click(object sender, RoutedEventArgs e)
    {
        proxy.On("ClientMethod", () =>
        {
            change_text("Hello");
        });
        
    }
    private void change_text(string text)
        {
           if (tb1.InvokeRequired)
            {
                tb1.Invoke(new MethodInvoker(delegate { tb1.Text = text; }));
            }
            else
            {
                tb1.Text = text;
            }
        }
