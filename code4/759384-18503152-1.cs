        private void myNewComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var cbox1 = sender as ComboBox;
            if (cbox1 != null)
            {
                if (cbox1.Name == "ComboBox1")
                {
                   var cbox2 = flowLayoutPanel2.Controls.OfType<ComboBox>().Where(c => c.Name == "ComboBox2").FirstOrDefault();
                   cbox2.SelectedValue = cbox1.SelectedValue.ToString();
                }
            } 
        }
