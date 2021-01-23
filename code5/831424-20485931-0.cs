    private void UpdateCollection(ComboBox comboBox)
        {
            if (comboBox.Text != "")
            {
                values = (from c in yourCollection
			                       where c.... (your conditions)
			                          select c).ToList();
            }
           
        }
