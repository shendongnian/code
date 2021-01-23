    private void Any_Click(object sender, EventArgs e)
    {
        Button b = (Button) sender;
        b.Enabled = false;
        guess = b.Text;
        GuessCheck();
    }
    
    int top = 50;
    int left = 100;
    for(int i = 'A'; i <= 'Z'; ++i)
    {
         var b = new Button();
         b.Text = (string)(char) i;
         v.Name = "btn" + b.Text;
         b.Left = left;
         b.Top = top;
         left += button.Width + 2;
         b.Click += Any_Click;
         this.Controls.Add(b);
    }
