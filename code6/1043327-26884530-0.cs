    private void button1_Click(object sender, EventArgs e)
    {
        Parallel.ForEach(Enumerable.Range(1, 100), (i) =>
        {
            Thread.Sleep(10);//Simulate some work
            this.Invoke(new Action(() => SetText(i)));
        });
    }
    private void SetText(int i)
    {
        textBox1.Text = i.ToString();
    }
