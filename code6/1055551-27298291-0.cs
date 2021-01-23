    var firmaIds = Enumerable.Range(0, gridView1.RowCount - 1).Select((index) =>
    {
        var siparisId = Convert.ToInt32(gridView1.GetRowCellValue(index, "SiparisNo"));
        var siparis = context.Siparisler.FirstOrDefault(p => p.Id == siparisId);
        return siparis != null ? siparis.Firma_Id : -1;
    }).Distinct();
    firmalarBindingSource.DataSource = context.Firmalar.Where(p => firmaIds.Contains(p.Id));
