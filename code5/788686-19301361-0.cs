    private void button2_Click(object sender, EventArgs e)
    {
        // find mybtn
        Button mybtn = this.Controls.FirstOrDefault(i => i.Name == "mybtn") as Button;
        if (mybtn != null)
        {
            Console.WriteLine(mybtn.Text);
        }
    }
