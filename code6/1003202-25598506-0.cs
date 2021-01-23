    foreach (DiseaseSymptom itemSelected in DiseaseSymptomsDataGrid.ItemsSource)
    {
        var cellContent = (CheckBox)StatusIdColumn.GetCellContent(itemSelected);
        if (cellContent != null && cellContent.IsChecked == true)
        {
            var entiParams = new DiseaseSymptomParams();
            entiParams.Id = DefaultValue.GetInt(itemSelected.Id);
            selectedDiseases.Add(entiParams);
        }
    }
