        public Form1()
        {
            InitializeComponent();
            for (int i = 0; i < 10; i++)
            {
                this.comboBox1.Items.Add(String.Format("Item {0}", i.ToString()));
            }
            foreach (Control C in this.Controls)
            {
                ComboBox cmbx = null;
                 
                // The & test ensures we're not just finding the source combobox
                if ((C.GetType() == typeof(ComboBox)) & ((C as ComboBox) != this.comboBox1))
                    cmbx = C as ComboBox;
                if (cmbx != null)
                {
                    foreach (Object item in comboBox1.Items)
                    {
                        cmbx.Items.Add(item);
                    }
                }
            }
        }
