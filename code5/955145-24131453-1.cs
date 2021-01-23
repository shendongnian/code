    private void button1_Click(object sender, EventArgs e)
    {
        if (hej)
        {
            saveFileDialog1.ShowDialog();
        }
        else
        {
            File.WriteAllText(filenamet, textBox1.Text);
        }
        // Reset after a save.
        hej = false;
        this.Text = Title;
    }
    
