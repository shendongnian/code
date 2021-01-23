    private void button2_Click(object sender, EventArgs e)
    {
        foreach (var comboBox in this.Controls.OfType<ComboBox>().ToList())
        {
            if (comboBox.Name.Equals("cboDynamic" + c.ToString()))
                this.Controls.Remove(comboBox); 
        }
    }
