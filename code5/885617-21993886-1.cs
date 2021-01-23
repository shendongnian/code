    private void propertyGrid_CustomDrawRowValueCell(object sender, DevExpress.XtraVerticalGrid.Events.CustomDrawRowValueCellEventArgs e)
    {
        if (propertyGrid.SelectedObject == null)
            return;
        System.Reflection.MemberInfo[] mi = (propertyGrid.SelectedObject.GetType()).GetMember(e.Row.Properties.FieldName);
        if (mi.Length == 1)
        {
            EditorControlAttribute attr = (EditorControlAttribute)Attribute.GetCustomAttribute(mi[0], typeof(EditorControlAttribute));
            if ((attr != null) && (e.Row.Properties.RowEdit == null))
            {
                e.Row.Properties.RowEdit = (DevExpress.XtraEditors.Repository.RepositoryItem)Activator.CreateInstance(attr.EditorType);
            }
        }
    }
