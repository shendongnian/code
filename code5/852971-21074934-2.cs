                List<MyClass> myList = new List<MyClass>();
                myList.Add(new MyClass() { URL = "A", Path = "1" });
                myList.Add(new MyClass() { URL = "B", Path = "2" });
                myList.Add(new MyClass() { URL = "C", Path = "3" });
                myList.Add(new MyClass() { URL = "D", Path = "4" });
                myList.Add(new MyClass() { URL = "E", Path = "5" });
    
    dataGridView1.DataSource = (from a in myList select new
                                            {
                                                URL = a.URL,
                                                Path = a.Path
                                            }).ToList();
    
    private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
    {
                var databaseRecordId = e.RowIndex;
                dataGridView1.Rows[e.RowIndex].Cells[0].Value = 555;
    }
