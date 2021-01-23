    private void saveBtn_Click(object sender, RoutedEventArgs e)
    {
        IEnumerable<MyEntity> updatedEntities = myGridData.Where(o => o.HasBeenUpdated == true);
        
        UpdateExistingMyEntity(updatedEntities);
        foreach(MyEntity e in updatedEntities)
            e.HasBeenUpdated = false;
    }
