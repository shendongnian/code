    Microsoft.Office.Interop.Excel.Application tempexcellApp= wb.Application;
   				Microsoft.Office.Interop.Excel.Worksheet tws = (Microsoft.Office.Interop.Excel.Worksheet)tempexcellApp.Worksheets[1];
				
				Microsoft.Office.Interop.Excel.Names Names = wb.Names;
				foreach(Microsoft.Office.Interop.Excel.Name item in Names)
				{
					if(item.Name.Contains("out_"))
					{
						string a = "";
						if(tws.Range[item.Name].Value2 != null)
						{
						 a  = item.Name + " " + tws.Range[item.Name].Value2.ToString();
						}else a = item.Name + " empty cell ";
						MessageBox.Show(a);
					}				
				}
