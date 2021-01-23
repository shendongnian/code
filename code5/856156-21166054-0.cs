        private void button1_Click(object sender, EventArgs e)
        {
            TextBox NewEmailBox = new TextBox();
            NewEmailBox.Name = "NewEmailBox" + this.panel1.Controls.Count;
            NewEmailBox.Dock = DockStyle.Top;
            this.panel1.Controls.Add(NewEmailBox);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            foreach (Control item in this.panel1.Controls)
            {
                if (item is TextBox)
                {
                    //Do your reading/validating here.
                }
                else
                {
                    throw new InvalidCastException(string.Format("{0} was in Panel1 and is of type {1} not TextBox!", item.Name, item.GetType()));
                }
            }
        }
