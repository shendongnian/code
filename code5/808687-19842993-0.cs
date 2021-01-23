        public static void TransferXLToTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("City", typeof(string));
            dt.Columns.Add("State", typeof(string));
            dt.Columns.Add("Zip", typeof(string));
            using (FileStream stream = new FileStream(OpenFile(), FileMode.Open, FileAccess.Read))
            {
                IWorkbook wb = new XSSFWorkbook(stream);
                ISheet sheet = wb.GetSheet("Sheet1");
                string holder;
                int i = 0;
                do
                {
                    DataRow dr = dt.NewRow();
                    IRow row = sheet.GetRow(i);
                    try
                    {
                        holder = row.GetCell(0, MissingCellPolicy.CREATE_NULL_AS_BLANK).ToString();
                    }
                    catch (Exception)
                    {
                        break;
                    }
                    
                    string city = holder.Substring(0, holder.IndexOf(','));
                    string state = holder.Substring(holder.IndexOf(',') + 2, 2);
                    string zip = holder.Substring(holder.IndexOf(',') + 5, 5);
                    dr[0] = city;
                    dr[1] = state;
                    dr[2] = zip;
                    dt.Rows.Add(dr);
                    i++;
                } while (!String.IsNullOrEmpty(holder));
            }
            using (FileStream stream = new FileStream(@"C:\Working\FieldedAddresses.xlsx", FileMode.Create, FileAccess.Write))
            {
                IWorkbook wb = new XSSFWorkbook();
                ISheet sheet = wb.CreateSheet("Sheet1");
                ICreationHelper cH = wb.GetCreationHelper();
                for (int i = 0; i < dt.Rows.Count; i++)
			    {
                    IRow row = sheet.CreateRow(i);
                    for (int j = 0; j < 3; j++)
                    {
                        ICell cell = row.CreateCell(j);
                        cell.SetCellValue(cH.CreateRichTextString(dt.Rows[i].ItemArray[j].ToString()));
                    }
			    }
                wb.Write(stream);
            }
        }
