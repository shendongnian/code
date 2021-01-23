       public Form1()
        {
            InitializeComponent();
            for (int i = 0; i < 10; i++)
            {
                this.comboBox1.Items.Add(String.Format("Item {0}", i.ToString()));
            }
            ComboBox cmbx = null;
            foreach (Control C in this.Controls)
            {
                // And test to make sure we didn't just find the source ComboBox.
                if ((C.GetType() == typeof(ComboBox)) & ((C as ComboBox) != this.comboBox1))
                    cmbx = C as ComboBox;
            }
            if (cmbx != null)
            {
                foreach (Object item in comboBox1.Items)
                {
                    cmbx.Items.Add(item);
                }
            }
        }
