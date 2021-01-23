	Button bt = new Button();
	bt.Click += bt_Click;
	bt.Text = "click me";
	bt.Location = new Point(100,100);
	this.Controls.Add(bt);
	private void bt_Click(object sender, EventArgs e)
	{
		label1.Text = (sender as Button).Text;
	}
