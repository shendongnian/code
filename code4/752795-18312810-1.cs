    DataTable dst = new DataTable();
    dst.Columns.Add("no", typeof(int));
    dst.Columns.Add("name", typeof(string));
    DataRow row = dst.NewRow();
    row[0] = 1;
    row[1] = "name1";
    
    DataRow row1 = dst.NewRow();
    row1[0] = 2;
    row1[1] = "name2";
    dst.Rows.Add(row);
    dst.Rows.Add(row1);
    dst.TableName = "DataGridviewTpXml";
    dst.WriteXml(@"C:\Users\prabu\Desktop\myxml.xml", true);
