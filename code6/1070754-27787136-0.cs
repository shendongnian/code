            Label lbl = new Label();
            lbl.Name = "label1";
            lbl.Parent = groupBox1;
            lbl.Text = "hello world";
            lbl.SetBounds(10, 10, 75, 21);
            Button btn = new Button();
            btn.Name = "button1";
            btn.Parent = groupBox1;
            btn.Text = "delete something";
            btn.SetBounds(10, 50, 75, 21);
            btn.Click +=btn_Click;
        void btn_Click(object sender, EventArgs e)
        {
            if (sender is Button)
            {
                MessageBox.Show("clicked on " + ((Button)sender).Name);
            }
        }
