       private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            ContextMenuStrip Menu = new ContextMenuStrip();
            ToolStripMenuItem MenuOpenPO = new ToolStripMenuItem("Delete it");
            MenuOpenPO.Click += new EventHandler(MenuOpenPO_Click);
            Menu.Items.AddRange(new ToolStripItem[] { MenuOpenPO });
            dataGridView1.ContextMenuStrip = Menu; //Assign to dataGridView1
        }
