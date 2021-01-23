    string Tracker = "";
    private void button2_Click(object sender, EventArgs e)
    {
        Tracker = "A";
        MessageBox.Show(Tracker);
        BeginInvoke((MethodInvoker)delegate
        {
            Tracker += "B";
            MessageBox.Show(Tracker);
        });
        Tracker += "C";
        MessageBox.Show(Tracker);
    }
