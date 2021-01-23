    private void button1_Click(object sender, EventArgs e)
    {
        this.button1.Enabled = false;
        Iterate();
    }
    IEnumerable<object> GetIterator()
    {
        string st = "hello my name is miroslav glamuzina";
        string[] arr = st.Split(' ');
        int i = 0;
        while (i < arr.Length)
        {
            label1.Text = arr[i];
            i++;
            yield return Type.Missing;
        }
    }
    void Iterate()
    {
        var enumerator = GetIterator().GetEnumerator();
        var timer = new System.Windows.Forms.Timer();
        timer.Interval = 1000;
        timer.Tick += (s, e) =>
        {
            if (!enumerator.MoveNext())
            {
                timer.Dispose();
                this.button1.Enabled = true;
            }
        };
        timer.Start();
    }
