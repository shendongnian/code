        int pyramidstories = int.Parse(TextBox2.Text);
        int I = 1;
        while (I <= pyramidstories)
        {
            for (int spacecount = 0; spacecount < (pyramidstories - I); spacecount++)
            {
                TextBox1.Text += " ";
            }
            for (int starcount = 1; starcount < I + 1; starcount++)
            {
                TextBox1.Text += "*";
            }
            TextBox1.Text += Environment.NewLine;
            I++;
        }
