    private void InitializeDataGridView()
    {
        ...
        _objectDataGridView.EditingControlShowing += (sender, e) =>
        {
            var cb = e.Control as ComboBox;
            if (_objectDataGridView.CurrentCellAddress.X == objectTypeComboBoxColumn.DisplayIndex && cb != null)
            {
                var value = _objectDataGridView[containerComboBoxColumn.DisplayIndex, _objectDataGridView.CurrentCellAddress.Y].Value;
                if(value != null)
                {
                    var containerId = (int)value;
                    using(var dao = _daoFactory.Create(_daoAdminRole))
                    {
                        var container = dao.Get<Container>(containerId);
                        var objectTypes = dao.GetByQueryObject(new ObjectTypeQueryObject {ContainerType = new ContainerType {Id = container.ContainerType.Id}});
                        cb.DataSource = objectTypes;
                    }
                }
            }
        };
        ...
    }
