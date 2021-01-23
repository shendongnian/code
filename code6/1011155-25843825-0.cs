        lstCombo.Clear();
                               foreach (DataRow dr in dt.Rows)
                               {
                                   lstCombo.Add(dr.Field<string>("ProductCode").ToString());
                               }
                               foreach (DataRow dr in dt.Rows)
                               {
                                   if (e.RowIndex == 0)
                                       ProductCode.Items.Add(dr.Field<string>("ProductCode").ToString());
                                   else
                                   {
                                       ProductCode.Items.Clear();
                                       int i = 0;
                                       foreach (var item in lstCombo)
                                       {
                                           if (item.ToString() == dgDetail.Rows[e.RowIndex - 1].Cells["ProductCode"].Value.ToString())
                                           { lstCombo.RemoveAt(i); break; }
                                           else i++;
                                       }
                                       foreach (var items in lstCombo) ;
                                       // ProductCode.
                                   }
                               }
