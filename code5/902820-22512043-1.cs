     private void ClickEvent()
            {
                var name = dataGridView1.Rows[1].Cells["2"] != null ? dataGridView1.Rows[1].Cells["2"].ToString() : "";
                var id = dataGridView1.Rows[1].Cells["3"] != null ? long.Parse(dataGridView1.Rows[1].Cells["3"].ToString()) : 0;
    
                var datalist = GetList(name, id, 16); //you have a copy of values with diffrent ids -- rest is for you
             }
      ///create a method which return copy of values but with different id
        private IEnumerable<LookUp> GetList(string name, long id,int till)
                {
                    for (var i = 1; i <= till; i++)
                    {
                        yield return new LookUp() { Id = i, Explanation = name,TeacherId = id};
                    }
                }
            
