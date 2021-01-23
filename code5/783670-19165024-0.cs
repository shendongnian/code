    public Form()
        {
            InitializeComponent();
    
            panel = new System.Windows.Forms.Panel();
            panel.Location = new System.Drawing.Point(90, 150);
            panel.Size = new System.Drawing.Size(200, 100);
            panel.Click += new System.EventHandler(this.panel_Click);
            this.Controls.Add(this.panel);
        }
      private void panel_Click(object sender, EventArgs e)
      {
        Point point = panel.PointToClient(Cursor.Position);
        MessageBox.Show(point.ToString());
      }
