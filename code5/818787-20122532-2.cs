     private void openForm()
        {
            if (!textBox1.Text.Equals("") && !textBox2.Text.Equals("") && !textBox3.Text.Equals("") && !textBox4.Text.Equals(""))
            {
                string fornavn = textBox1.Text;
                string efternavn = textBox2.Text;
                string medarbejdernr = textBox3.Text;
                string organisation = textBox4.Text;
                Form f = new Form1(fornavn, efternavn, medarbejdernr, organisation, this);
                f.Show();
                this.Visible = false;
                Listener listen = null;
                var taskListener = Task.Factory.StartNew(() =>
                                    listen = new Listener());
            }
            else
            {
                MessageBox.Show("Du skal angive noget i alle felter", "Fejl", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
