    private void button1_Click(object sender, EventArgs e)
    {
        System.Threading.Thread T = new System.Threading.Thread(Foo);
        T.Start();
    }
    delegate bool SetTestDelegate(string text);
    private bool SetTest(string text)
    {
        return (MessageBox.Show(text, "", MessageBoxButtons.YesNo) == DialogResult.No);
    }
    private void Foo()
    {
        if ((bool)this.Invoke(new SetTestDelegate(SetTest), new object[] {"test"}))
        {
            Console.WriteLine("No was indeed selected.");
        }
    }
