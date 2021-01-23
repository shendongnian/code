    private void button1_Click(object sender, EventArgs e)
    {
        panel.Clear(); // *see Hans comment
        (new Thread(LongRunningMethod)).Start();
    }
    private void LongRunningMethod()
    {
        // ... retrieve items
        Invoke(() =>
        {
            // ... add items to panel
        });
    }
