    dataGridView.Columns.Add(new DataGridViewComboBoxColumn
    {
        Name = "ArticleColumn",
        DataSource = listArticles,
        ValueMember = "ID",
        DisplayMember = "Name",
        DataPropertyName = "ArticleID"
    });
