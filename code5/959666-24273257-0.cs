        private void ElegantwaytoBindDictionarywithList()
        {
            var dict = new Dictionary<string, List<string>>
            {
                {
                    "Foo", new List<string>{"foo1","foo2"}
                },
                {
                    "Bar", new List<string>{"bar1","bar2"}
                }
            };
            var source = new BindingSource {DataSource = dict};
            dataGridView1.RowsAdded += (sender, args) =>
            {
                var key = dict.Skip(args.RowIndex).First().Key;
                dataGridView1.Rows[args.RowIndex].Cells["value"].Value = string.Join(", ", dict[key]);
            };
            dataGridView1.Columns.Add("value", "value");
            dataGridView1.DataSource = source;
        }
