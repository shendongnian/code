	public Form1()
	{
		private Form2 sub = null;
		
		public Form1()
		{
			InitializeComponent();
			sub = new Form2();
			// you don't need this, for adding a new row
			sub.RegisterParentAndInitGrid(this);
			//
			sub.ShowDialog();
		}
		private void button1_Click(object sender, EventArgs e)
		{
			sub.AddRow(new string[] { "3","4"});
		}
	}
	public Form2()
	{
		{
			InitializeComponent();
		}
		private Form1 _parent;
		internal void RegisterParentAndInitGrid(Form1 form)
		{
			this._parent = form;
			for (int x = 1; x <= 5; x++ )
			{
				string[] row;
				row = new string[] { "1","2"};
				sub.DGVFile.Rows.Add(row);
			}
		}
		
		public void AddRow(string[] values)
		{
			sub.DGVFile.Rows.Add(values);
		}
	}
