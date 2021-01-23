     private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
            {
                
                TextBox autoText = e.Control as TextBox;
                autoText.TextChanged += autoText_TextChanged;
            }
    
            void autoText_TextChanged(object sender, EventArgs e)
            {
                TextBox autoText = sender as TextBox;
                if (autoText != null && autoText.Text[0] == '@')
                {
                    autoText.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    autoText.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    var source = new AutoCompleteStringCollection();
                    source.AddRange(new string[] { "@MyValue" });
                    autoText.AutoCompleteCustomSource = source;
    
                }
            }
