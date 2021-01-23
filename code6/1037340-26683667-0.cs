    if (dtData == null)
                {
                    //set DataSource of DataGrid
                    dtData = dTable.Copy();
                    datGrid.DataSource = dtData;
                }
                else
                {
                    dtData.BeginLoadData();
                    foreach (DataRow row in dTable.Rows)
                        dtData.LoadDataRow(row.ItemArray, true);
                    dtData.EndLoadData();
                }
