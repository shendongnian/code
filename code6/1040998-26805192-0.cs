    private void button_Click_1(object sender, RoutedEventArgs e)
    {
        int i;
        string allLines = "";
        for (i = 1; i <= 10; i++)
            allLines += new string('X', i) + (i < 10 ? "\n" : "");
        txt_box1.Text = allLines;
        txt_box2.Text = allLines;
        allLines = "";
        while (--i > 0)
            allLines += new string('X', i) + (i > 1 ? "\n" : "");
        txt_box3.Text = allLines;
        txt_box4.Text = allLines;
    }
