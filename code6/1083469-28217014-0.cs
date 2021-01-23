        private void buttonLagra_Click(object sender, EventArgs e)
        {
            Kontakter nyKontakt = new Kontakter();
            {
                nyKontakt.Telefonnr = textBoxTelefonnr.Text;
                nyKontakt.Namn = textBoxNamn.Text;
            }
            bool exists = false;
            foreach (var item in kontackter)
            {
                if (item.Namn == nyKontakt.Namn)
                {
                    exists = true;
                    break;
                }
            }
            if (!exists)
            {
                kontakter.Add(nyKontakt);
                listBox1.DataSource = null;
                listBox1.DataSource = kontakter;
                BinaryFormatter bf = new BinaryFormatter();
                FileStream fs = new FileStream(filnamn, FileMode.OpenOrCreate, FileAccess.Write);
                bf.Serialize(fs, kontakter);
                fs.Close();
            }
        }
