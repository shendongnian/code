        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.Text)
            {
                case "Something":
                    comboBox2.Items.Clear();
                    comboBox2.Items.Add("Option1");
                    comboBox2.Items.Add("Option2");
                    comboBox2.Items.Add("Option3");
                    break;
                case "Something else":
                    comboBox2.Items.Clear();
                    comboBox2.Items.Add("Option4");
                    comboBox2.Items.Add("Option5");
                    comboBox2.Items.Add("Option6");
                    break;
                default:
                    break;
            }
        }
