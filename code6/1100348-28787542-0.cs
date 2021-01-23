    dataTLocationsTransposed =  FkDataAccess.GetLocationDetailsTransposed(selectedPostCombined);
                List<DataRow> list1 = new List<DataRow>();
                foreach (DataRow dr in dataT.Rows)
                {
                    list1.Add(dr);
                }
                List<DataRow> list2 = new List<DataRow>();
                foreach (DataRow dr in dataTLocationsTransposed.Rows)
                {
                    list2.Add(dr);
                }
                dataTMerged = list2.Union(list1).CopyToDataTable();
                this.dataGridView1.DataSource = dataTMerged;
