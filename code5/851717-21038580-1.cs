            // your application fills this collection using data from database
            var source = new List<MyEntity>
            {
                new MyEntity { Id = 1, Name = "Apple" },
                new MyEntity { Id = 2, Name = "Orange" },
                new MyEntity { Id = 3, Name = "Plum" },
                new MyEntity { Id = 4, Name = "Peach" },
            };
            dataGridView1.DataSource = new BindingList<MyEntity>(source);
