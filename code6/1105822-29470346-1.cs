        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            AddGrid();
            BindingList<Worker> lst = new BindingList<Worker>() { new Worker() { ID = 1, Name = "Adam" }, new Worker() { ID = 2, Name = "Eva" } };
            radGridView1.DataSource = lst;
        }
        class Worker
        {
            public int ID { get; set; }
            public string Name { get; set; }
        }
        private void radButton1_Click(object sender, EventArgs e)
        {
            Worker displayedWorker = (Worker)radGridView1.CurrentRow.DataBoundItem;
            BindingList<Worker> tableDataSource = (BindingList<Worker>)radGridView1.DataSource;
            int indexInTableDataSource = tableDataSource.IndexOf(displayedWorker);
          
            Worker changedWorkerFromDataBase = new Worker() { ID = 1, Name = "new name" };
            tableDataSource[indexInTableDataSource] = changedWorkerFromDataBase;
        }
