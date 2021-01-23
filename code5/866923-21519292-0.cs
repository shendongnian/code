    class MigratedDataItems
        {
            public string Name { get; set; }
            public string DataType { get; set; }
            public string MediaSize { get; set; }
            public int NumItems { get; set; }
            public int HandlingCost { get; set; }
            public int UnitPrice { get; set; }
            public int Total { get; set; }
        }
    public List<MigratedDataItems> QuoteList()                    
        {
            List<MigratedDataItems> migDataList = new List<MigratedDataItems>();
            foreach (DataGridViewRow dgRow in dataGridView1.Rows)
            {
                MigratedDataItems item = new MigratedDataItems();
                foreach (DataGridViewCell dc in dgRow.Cells)
                {
                    if (dc.OwningColumn.Index == 0) { item.Name = dc.Value.ToString(); }
                    if (dc.OwningColumn.Index == 1) { item.DataType = dc.Value.ToString(); }
                    if (dc.OwningColumn.Index == 2) { item.MediaSize = dc.Value.ToString(); }
                    if (dc.OwningColumn.Index == 3) { item.NumItems = int.Parse(dc.Value.ToString()); }
                    if (dc.OwningColumn.Index == 4) { item.HandlingCost = int.Parse(dc.Value.ToString()); }
                    if (dc.OwningColumn.Index == 5) { item.UnitPrice = int.Parse(dc.Value.ToString()); }
                    if (dc.OwningColumn.Index == 6) { item.Total = int.Parse(dc.Value.ToString()); }
                }
                migDataList.Add(item);
            }
            return migDataList;
         }
