    public List<DiseaseSymptomParams> GetSelectedDiseaseSymptom()
    {
        var selectedDiseases = new List<DiseaseSymptomParams>();
        try
        {
            foreach (DiseaseSymptom itemSelected in DiseaseSymptomsDataGrid.ItemsSource)
            {
                var cellContent = (CheckBox)StatusIdColumn.GetCellContent(itemSelected);
                if (cellContent != null && cellContent.IsChecked == true)
                {
                    var entiParams = new DiseaseSymptomParams
                    {
                        Id = DefaultValue.GetInt(itemSelected.Id)
                    };
                    selectedDiseases.Add(entiParams);
                }
            }
        }
        catch (Exception)
        {
        }
        return selectedDiseases;
    }
