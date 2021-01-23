        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form form = new Form() { StartPosition = FormStartPosition.CenterScreen, Width = 1280, Height = 720 };
            MarqueeListView list = new MarqueeListView() { View = View.Tile, Dock = DockStyle.Fill };
            for (int i = 0; i < 1000; i++) { list.Items.Add(Guid.NewGuid().ToString()); }
            form.Controls.Add(list);
            Application.Run(form);
        }
