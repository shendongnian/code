    for (int k = 0; k < 2; k++)
    {
        Button Btn = new Button();
        Btn.Name = "btn" + k;
        Btn.Location = new System.Drawing.Point(20 + (k *110), 60 + (20 * j) * 2);
        Btn.Size = new System.Drawing.Size(90, 30);
         if (k == 0)               
            Btn.Text = "Back";
         else
            Btn.Text = "Calculate";
        Btn.Click += button_Click; // <-- This is where it happens!
        this.Controls.Add(Btn);
    }
