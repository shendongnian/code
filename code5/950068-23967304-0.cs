    private void button1_Click(object sender, EventArgs e)
        {
            for (int t = 0; t < 4;t++ )
                tabControl1.TabPages.Add(CreateTabPage(t));
        }
    
        private TabPage CreateTabPage(int t)
        {
    
            TabPage result = new TabPage()
            {
                Text=string.Format("TabPage {0}",t)
            };
            FlowLayoutPanel flp = new FlowLayoutPanel()
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
            };
            for (int i = 0; i < 10; i++)
            {
                flp.Controls.Add(CreateGroupBox(i));
            }
            result.Controls.Add(flp);
            return result;
        }
    
        private Control CreateGroupBox(int i)
        {
            GroupBox result = new GroupBox()
            {
                Text = string.Format("GroupBox {0}", i),
                Width = 150,
                Height = 100
            };
            FlowLayoutPanel flp = new FlowLayoutPanel()
            {
                Dock = DockStyle.Fill,
                WrapContents = false,
                AutoScroll = true,
                FlowDirection=FlowDirection.TopDown
            };
            CreateRadios(flp, i);
            result.Controls.Add(flp);
            return result;
        }
    
        private void CreateRadios(FlowLayoutPanel flp, int i)
        {
            for (int c = 0; c < 10; c++) {
                flp.Controls.Add(new RadioButton()
                {
                    Text = string.Format("RadioButton {0} in {1}", c, i)
                });
            }
        }
