     public Form1()
            {
                InitializeComponent();
                ContextMenu cm = new ContextMenu();
                cm.MenuItems.Add("Remove", new EventHandler(rmv_click));
                cm.MenuItems.Add("Rename", new EventHandler(rename_click));
                tabControl1.ContextMenu = cm;
            }
    
            //select tab on right mouse click
            private void tabControl_MouseDown(object sender, MouseEventArgs e)
            {
                if (e.Button == MouseButtons.Right)
                {
                    for (int i = 0; i < this.tabControl1.TabCount; ++i)
                    {
                        if (this.tabControl1.GetTabRect(i).Contains(new Point(e.X, e.Y)))
                        {
                            this.tabControl1.SelectedIndex = i;
                            break;
                        }
                    }
                }
            }
    
            //remove selected tab
            private void rmv_click(object sender, System.EventArgs e)
            {
                tabControl1.TabPages.Remove(tabControl1.SelectedTab);
            }
    
            //rename selected tab
            private void rename_click(object sender, System.EventArgs e)
            {
                var showDialog = this.ShowDialog("Tab Name", "Rename the selected tab");
                tabControl1.SelectedTab.Text = showDialog;
            }
    
            public string ShowDialog(string text, string caption)
            {
                Form prompt = new Form();
                prompt.Width = 500;
                prompt.Height = 150;
                prompt.Text = caption;
                Label textLabel = new Label() { Left = 50, Top = 20, Text = text };
                TextBox textBox = new TextBox() { Left = 50, Top = 50, Width = 400 };
                Button confirmation = new Button() { Text = "Ok", Left = 350, Width = 100, Top = 70 };
                confirmation.Click += (sender, e) => { prompt.Close(); };
                prompt.Controls.Add(confirmation);
                prompt.Controls.Add(textLabel);
                prompt.Controls.Add(textBox);
                prompt.ShowDialog();
                return textBox.Text;
            }
