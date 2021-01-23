    private void trigger(object sender, EventArgs e, string bla = "")
    {
        if (bla.Length > 0)
        {
            MessageBox.Show(bla);
        }
        else
        {
            MessageBox.Show("Hi!");
        }
    }
    private void button1_Click(object sender, EventArgs e)
    {
        trigger(sender, e);
    }
    private void button1_trigger()
    {
        trigger(null, null, "hi");
    }
