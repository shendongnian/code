    dataGridView.Columns.Add(new DataGridViewComboBoxColumn
    {
        Name = "CategoryColumn",
        DataSource = listCategories,
        ValueMember = "ID",  // property of our class Category
        DisplayMember = "Name", // property of our class Category
        DataPropertyName = "CategoryID" // bind it to the property CategoryID from our class MyDataSource
    });
    ...
