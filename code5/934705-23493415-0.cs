    class clazz
    {
        public event BrugerSprogChanged brugerSprogChanced;
        public clazz(){}
    
        private void comboBoxDokumentSprog_SelectedIndexChanged(object sender, EventArgs e)
        {
            Sprog sprog = FindSprog((string)((ComboBox)sender).SelectedItem);
    	    if (dokumentSprogChanged != null)
    	    {
                dokumentSprogChanged(this, sprog); // <- here we have the problem
    	    }
        }
    }
