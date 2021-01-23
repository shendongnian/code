        public Dictionary<IntPtr, string> forms = new Dictionary<IntPtr, string>();
        private void button1_Click(object sender, EventArgs e)
        {
            var newForm = new Form();
            newForm.Text = "New Form Text";
            forms.Add(newForm.Handle, newForm.Text);
            //look through our dictionary to find if the form exists
            //if it does, update the value, otherwise add a new entry
            if (forms.Keys.Contains(newForm.Handle))
                forms[newForm.Handle] = newForm.Text;
            else
                forms.Add(newForm.Handle, newForm.Text);
            
            RefreshDatasource();
        }
        private void RefreshDatasource()
        {
            checkedListBox1.DataSource = forms.ToList();
            checkedListBox1.DisplayMember = "Value";
        }
