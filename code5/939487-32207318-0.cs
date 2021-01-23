        public void UpdateAttributes(ComboBox sender)
        {
            var definitions = _attributeDefinitions.ToList();
            {
                var combobox = cmbAttributeDefinition1;
                if (sender != combobox && combobox.SelectedValue != null)
                    definitions.RemoveAll(
                        x => x.AttrID == (imProfileAttributeID)combobox.SelectedValue);
            }
            {
                var combobox = cmbAttributeDefinition2;
                if (sender != combobox && combobox.SelectedValue != null)
                    definitions.RemoveAll(
                        x => x.AttrID == (imProfileAttributeID)combobox.SelectedValue);
            }
            {
                var combobox = cmbAttributeDefinition3;
                if (sender != combobox && combobox.SelectedValue != null)
                    definitions.RemoveAll(
                        x => x.AttrID == (imProfileAttributeID)combobox.SelectedValue);
            }
            {
                var combobox = cmbAttributeDefinition4;
                if (sender != combobox && combobox.SelectedValue != null)
                    definitions.RemoveAll(
                        x => x.AttrID == (imProfileAttributeID)combobox.SelectedValue);
            }
            {
                var combobox = cmbAttributeDefinition5;
                if (sender != combobox && combobox.SelectedValue != null)
                    definitions.RemoveAll(
                        x => x.AttrID == (imProfileAttributeID)combobox.SelectedValue);
            }
            sender.DataSource = definitions;
            sender.DisplayMember = "Caption";
            sender.ValueMember = "AttrID";
        }
      private void cmbAttributeDefinition1_DropDown(object sender, EventArgs e)
        {
            UpdateAttributes(sender as ComboBox);
        }
        private void cmbAttributeDefinition5_DropDown(object sender, EventArgs e)
        {
            UpdateAttributes(sender as ComboBox);
        }
        private void cmbAttributeDefinition2_DropDown(object sender, EventArgs e)
        {
            UpdateAttributes(sender as ComboBox);
        }
        private void cmbAttributeDefinition3_DropDown(object sender, EventArgs e)
        {
            UpdateAttributes(sender as ComboBox);
        }
        private void cmbAttributeDefinition4_DropDown(object sender, EventArgs e)
        {
            UpdateAttributes(sender as ComboBox);
        }
