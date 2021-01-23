    for (int count = 0; count < input.Count; count++)
                {
                    TextBox tb = new TextBox();
                    tb.Name = "text_Box_line" + count.ToString();
                    tb.Text = input[count].ToString();
                    Point p = new Point(100, 30 * count);
                    tb.Location = p;
                    tb.AutoSize = True;
                    tb.SelectionStart = tb.Text.Length;
                    tb.ScrollToCaret();
    
                    this.Controls.Add(tb);
                }
