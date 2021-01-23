    DataTable dt = new DataTable();
    DataColumn dc = new DataColumn("Column1");
    dc.DataType = System.Type.GetType("System.Byte[]");
    dt.Columns.Add(dc);
    DataRow row = dt.NewRow();
    var imageConverter = new ImageConverter();
    row["Column1"] = imageConverter.ConvertTo(Properties.Resources._1, System.Type.GetType("System.Byte[]")); 
    dt.Rows.Add(row);
