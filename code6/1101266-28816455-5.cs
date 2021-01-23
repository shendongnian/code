    private void button1_Click(object sender, EventArgs e)
    {
        System.Threading.Timer timer = new System.Threading.Timer(UpdateText, null, 1000, System.Threading.Timeout.Infinite);
    }
    
    public void UpdateText(object state)
    {
        MethodInvoker action = delegate
        {
            this.textBox1.AppendText("Ouch!" + Environment.NewLine);
        };
    
        this.textBox1.BeginInvoke(action);
    }
