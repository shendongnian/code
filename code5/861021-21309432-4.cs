    // Check if guids.Length > 0
    StringBuilder filter = new StringBuilder("ID IN ("); 
    foreach (Guid id in guids)
        filter.AppendFormat("Convert('{0}','System.Guid'),", id);
    filter.Append(")");
    DataTable template = ReadTemplateList();
    DataView view = template.DefaultView;
    view.RowFilter = filter.ToString();
    DataTable table = view.ToTable();
