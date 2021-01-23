    private void quantitybox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsDigit(e.KeyChar) || e.KeyChar == '\b'); //OR: e.KeyChar==8
        }
        public invmain CreatedItem { get; private set; }
        public void add_Click(object sender, EventArgs e)
        {           
            //SWITCH STATEMENT FOR DIRECTING USER-ENTERED INVENTORY DATA  
            //TO THE APPROPRIATE TABCONTROL TAB AND DGV<1:4>
            //OBJECT REFERENCE TO DGV
            invmain invmainobject = new invmain();
            switch(combobox1.SelectedIndex)
            {
                case 0: //ELECTRICAL
                    invmainobject.datagridview1.Rows.Add(itembox.Text, quantitybox.Text);
                    break;
                case 1: //MECHANICAL
                    invmainobject.datagridview2.Rows.Add(itembox.Text, quantitybox.Text);
                    break;
                case 2: //CABLES
                    invmainobject.datagridview3.Rows.Add(itembox.Text, quantitybox.Text);
                    break;
                case 3: //MISC.
                    invmainobject.datagridview4.Rows.Add(itembox.Text, quantitybox.Text);
                    break;
                default:
                    MessageBox.Show("Please select a category.\t\t", "Required Field Missing", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    combobox1.Focus();
                    return;
            }
            if (string.IsNullOrWhiteSpace(this.itembox.Text))
            {
                MessageBox.Show("The 'Item' field is required.\t\t\t", "Required Field Missing", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                itembox.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(this.quantitybox.Text))
            {
                MessageBox.Show("The 'Quantity' field is required.\t\t\t", "Required Field Missing", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                quantitybox.Focus();
                return;
            }
            this.DialogResult = DialogResult.OK;
            this.Dispose();
            this.CreatedItem = invmainobject;
        }
