    int count = 0;
    foreach (var person in PersonList.ItemSource)
    {
        var row = PersonList.ItemContainerGenerator.ContainerFromItem(person) as DataGridRow;
        if (PersonDataTable.Rows[count].Field<int>(1) > 50)
        {
            row.DefaultCellStyle.BackColor = Color.Gray; 
        }
        count++;
    }
