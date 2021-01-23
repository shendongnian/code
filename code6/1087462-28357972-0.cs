    Form2 f = new Form2();
		public Form1()
		{
			InitializeComponent();
		}
		private void Form1_Load(object sender, EventArgs e)
		{
			f = new Form2()
			{
				Top = 0,
				Left = 0,
				Width = 100,
				Height = 100,
				TopLevel = false
			};
		}
		private void button1_Click(object sender, EventArgs e)
		{
			
			int x = int.Parse(this.textBox1.Text);			   
			this.tabControl1.TabPages[x].Controls.Add(f);
			f.Show();
			this.tabControl1.Refresh();
		}
