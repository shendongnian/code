    DataTable dt = new DataTable();
    dt = clsTransmit.FillDataTable("SELECT brandName, brandPic FROM brands", false);
            
    int count = dt.Rows.Count;
    string[] names = dt.AsEnumerable().Select(row => row.Field<string>("brandName")).ToArray();
    string[] pics = dt.AsEnumerable().Select(row => row.Field<string>("brandPic")).ToArray();
    foreach (var item in pics)
    {
       Image img = Image.FromFile(item);
       imgList.Images.Add(img);
    }
            
    dgv.Columns.Add("brandName", "Brand Name");
            
    for (int i = 0; i < count; i++)
    {
       dgv.Rows.Add(new object[] {names[i]});
    }
    DataGridViewImageColumn imageCol = new DataGridViewImageColumn();
    dgv.Columns.Add(imageCol);
    dgv.Columns[1].HeaderText = "Brand Logo";
    dgv.Rows.Add();
    for (int i = 0; i < count; i++)
    {
       dgv.Rows[i].Cells[1].Value = imgList.Images[i];
    }
    dgv.Rows.RemoveAt(count);
