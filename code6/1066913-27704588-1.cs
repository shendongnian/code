    private void AutoComplete()
            {
                AutoCompleteStringCollection _dataCollections = new AutoCompleteStringCollection();
    
                Manager.AutoComplete(_dataCollections);
    
                textBox2.AutoCompleteMode = AutoCompleteMode.Suggest;
    
                textBox2.AutoCompleteSource = AutoCompleteSource.CustomSource;
    
                textBox2.AutoCompleteCustomSource = _dataCollections;
            }
    private void textBox2_TextChanged(object sender, EventArgs e)
            {
                Manager.GetData(this.textBox2, this.textBox1, this.textBox3, this.numericUpDown1);
            }
