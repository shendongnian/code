    private void SetDataSource(IEnumerable<Object> assignedObjects, 
                               List<Container> subContainersAssociatedWithSystem)
    {
        _objectDataGridView.Rows.Clear();
        foreach (var assignedObject in assignedObjects)
        {
            var newRowIndex = _objectDataGridView.Rows.Add();
            var row = _objectDataGridView.Rows[newRowIndex];
            row.Cells["Id"].Value = assignedObject.Id;
            row.Cells["Name"].Value = assignedObject.Name;
            var containerColumn = (DataGridViewComboBoxCell)row.Cells["Container"];
            containerColumn.DataSource = subContainersAssociatedWithSystem;
            containerColumn.Value = assignedObject.Container.Id;
            var objectTypeColumn = (DataGridViewComboBoxCell)row.Cells["Type"];
            objectTypeColumn.DataSource = new List<ObjectType> {assignedObject.ObjectType};
            objectTypeColumn.Value = assignedObject.ObjectType.Id;
        }
    }
