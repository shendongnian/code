    private void button1_Click(object sender, EventArgs e)
    {
        this.button1.Enabled = false;
        Iterate();
    }
    IEnumerable GetIterator()
    {
        string st = "hello my name is Noseratio";
        string[] arr = st.Split(' ');
        foreach (var s in arr)
        {
            label1.Text = s;
            yield return Type.Missing;
        }
    }
    void Iterate()
    {
        var enumerator = GetIterator().GetEnumerator();
        var timer = new System.Windows.Forms.Timer();
        timer.Interval = 1000;
        timer.Tick += delegate
        {
            if (!enumerator.MoveNext())
            {
                timer.Dispose();
                this.button1.Enabled = true;
            }
        };
        timer.Start();
    }
