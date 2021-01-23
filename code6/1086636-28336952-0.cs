    IList<Person> FindPersons(string nameFilter, string addressFilter, 
                              DateTime? birthdate, .. etc)
    {
       using (var db = new DbDataContext())
       {
         var query = db.Persons.AsQueryable();
         if (!string.IsNullOrWhitespace(nameFilter))
         {
            query = query.Where(p => p.FullName.Contains(nameFilter));
         }
         if (!string.IsNullOrWhitespace(addressFilter))
         {
            query = query.Where(p => p.Address == addressFilter);
         }
         if (!string.IsNullOrWhitespace(depFilter))
         {
            query = query.Where(p => p.Department == depFilter);
         }
         if (birthdate.HasValue)
         {
            query = query.Where(p => p.Birthdate == birthdate);
         }
         query = query.Take(1000); // Sanity, limit the rows
    
         return query.ToList();
       }
    }
    protected void OnSearchPersonClick()
    {
        // Parsing
        var nameFilter = txtSearch.Text;
        var addressFilter = comboBox1.SelectedIndex > 0 ? comboBox1.Text : "";
        DateTime? birthdate = chkBirthdate.Checked 
               ? dateTimePicker1.Value.Date 
               : (DateTime?) null;       
        // etc
        // Validation
        if (string.IsNullOrWhitespace(nameFilter) 
            && string.IsNullOrWhitespace(addressFilter) 
            && !(birthdate.HasValue)) // etc
        {
            ShowErrorMessageToUser("Please provide at least one filter");
            return;
        }
        // Bind
        dataGridView1.DataSource = FindPersons();
    }
