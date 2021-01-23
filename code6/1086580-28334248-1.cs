        private void buttonloadmod_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            if (!String.IsNullOrEmpty(ModList.Text))
            {
                for (int index = 0; index < ModList.Items.Count; index++)
                {
                    string item = ModList.Items[index].ToString();
                    if (ModList.Text == item)
                    {
                        ModList.SelectedItem = index;
                        storedvar.passedMod = item;
                        this.Hide();
                        f2.ShowDialog();
                        break;
                    }
                }
            }
        }
