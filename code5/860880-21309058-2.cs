    private void button1_Click(object sender, EventArgs e)
    {
        (new Thread(method)).Start();
    }
    private void method()
    {
        //Code
        Invoke((Action)(() =>
        {
            //SaveFileDialog
        }));
    }
