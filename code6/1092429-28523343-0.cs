    public void initialize_MyForm()
        {
            ComboBox cboSourceType = new ComboBox(); // Where you define it
            cboSourceType.Items.Add("ODBC");
            cboSourceType.Items.Add("CSV");
            cboSourceType.SelectedIndex = 0;
            tabMyFrom.TabPages[0].Controls.Add(cboSourceType);
            cboSourceType.SelectedIndexChanged += new System.EventHandler(cboSourceType_SelectedIndexChanged);           
        }
    
        public void cboSourceType_SelectedIndexChanged(object sender, EventArgs e)
        {           
            // Try to access it from here : out of the scope 
            switch (cboSourceType.SelectedIndex)
            {
                case 1:  //ODBC - Handle this selection
                    break;
                case 2:  //CSV - Handle this selection
                    break;
            }
        }
