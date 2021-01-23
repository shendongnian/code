    int loc = 20;
    for (int i = 0; i < 5; i++)
    {
        GroupBox gb = new GroupBox();
        gb.Size = new Size(500, 200);
        gb.Location = new Point(40, loc);
        gb.BackColor = System.Drawing.Color.Aquamarine;
    
        Label q_text = new Label(); // текст питання
        q_text.Text = "Питання" + (i + 1);
        q_text.Font = new Font("Aria", 10, FontStyle.Bold);
        q_text.Location = new Point(0, 0);
        gb.Controls.Add(q_text);
        int iter = q_text.Location.Y + 30;
    
        foreach (string key in questions[i].answers.Keys)
        {
            RadioButton rb = new RadioButton();
            rb.Text = key;
            rb.Size = new Size(120, 25);
            rb.Location = new Point(q_text.Location.X + 10, iter);
            iter += 30;
            gb.Controls.Add(rb);
        }
    
        this.Controls.Add(gb);
        loc += 300;
    }
