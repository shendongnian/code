    Button btnNew = new Button();
    btnNew.Text = "";
    btnNew.Height = 108;
    btnNew.Width = 230;
    btnNew.Image = new Bitmap(textBox1.Text);
    btnNew.FlatStyle = FlatStyle.Flat;
    flpContainer.Controls.Add(btnNew);
    btnNew.Click += btnNew_Click;
    btnNew.Tag = textBox2.Text;// <--Store it in Tag
