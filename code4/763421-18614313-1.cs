        private void RobCsvKopieren_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.f_sOudeLocatie != "")
            {
                fdlg.InitialDirectory = f_sOudeLocatie;
            }else
	        {
                fdlg.InitialDirectory = Properties.Settings.Default.f_sOudeLocatie;
	        }
            this.Location = Properties.Settings.Default.LastFormLocation;
            this.Size = Properties.Settings.Default.LastFormSize;
        }
