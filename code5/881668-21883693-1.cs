        int maxNo = 4; //you can change this no and logic works till 9 comboboxes
        void clearPreceding(ComboBox cmbBox)
        {
            int cmbBoxNo = Convert.ToInt32(cmbBox.Name.Substring(cmbBox.Name.Length - 1));
            for (int i = cmbBoxNo; i <= maxNo; i++)
            {
                ((ComboBox)this.Controls.Find("comboBox" + i, true)[0]).Text = "";
            }
        }
