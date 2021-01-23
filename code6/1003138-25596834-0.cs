    foreach (DiseaseSymptom item in DiseaseSymptomsDataGrid.ItemsSource)
    {
        if (((CheckBox)StatusIdColumn.GetCellContent(item)).IsChecked == true)
        {
            selectedDiseases.Add(item);
        }
    }
