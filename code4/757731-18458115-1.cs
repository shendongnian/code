    DataGridColumn column = info.GetCustomAttributes(typeof(DbComboBoxAttribute), true).Any()
        ? CreateComboBoxColumn(path, info, header, repository)
        : info.GetCustomAttributes(typeof(DescribedByteEnumComboBoxAttribute), true).Any()
        ? CreateEnumComboBoxColumn(path, info, header)
        : info.GetCustomAttributes(typeof(DropDownLazyLoadingDataGridAttribute), true).Any()
        ? CreateDataGridDropDownLazyLoadingDataGridColumn(path, info, header, repository)
        : info.GetCustomAttributes(typeof(DropDownTreeViewAttribute), true).Any()
        ...
        : CreateTextBoxColumn(path, info, header);
