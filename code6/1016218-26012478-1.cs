    int i=0; // Define i at class level
    private void button1_Click(object sender, EventArgs e)
    {    
        Random x = new Random();
        
            i++;
            Point pt = new Point(
                int.Parse(x.Next(400).ToString()), 
                int.Parse(x.Next(250).ToString())
                );
            button1.Location = pt;
            textBox1.Text = "Hits: " + i;
    }
