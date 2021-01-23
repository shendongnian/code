        private void RobCsvKopieren_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.f_sOudeLocatie = f_sOudeLocatie;
            Properties.Settings.Default.f_sNieuweLocatie = f_sNieuweLocatie;
            Properties.Settings.Default.LastFormLocation = this.Location;
            Properties.Settings.Default.LastFormSize = this.Size;
            myRegistry.Write("Size", Size);
            Properties.Settings.Default.Save();
        }
