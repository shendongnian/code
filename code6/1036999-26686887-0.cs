                         Int64 iItemId = Convert.ToInt64(gvItemMaster.GetRowCellValue(e.RowHandle, "ItemID"));
                         bool bDiscount = Convert.ToBoolean(e.Value);
                    for (int i = 0; i < gvItemMaster.DataRowCount; i++)
                    {
                        Int64 id = Convert.ToInt64(gvItemMaster.GetRowCellValue(i, "ItemID"));
                        if (id == iItemId)
                        {
                            if (bDiscount)
                                gvItemMaster.SetRowCellValue(i, gvItemMaster.Columns[""+sColumn.Replace(" ","")+""], true);
                            else
                                gvItemMaster.SetRowCellValue(i, gvItemMaster.Columns[""+sColumn.Replace(" ","")+""], false);
                        }
                    }   
