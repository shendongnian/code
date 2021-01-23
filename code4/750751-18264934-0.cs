        private void Form1_Load(object sender, EventArgs e)
        {
            var dset = Db.Tasks;   // Db is my context.
            DbSet<Task> qry = dset;
            qry.Load();
            bindingSource1.DataSource  =dset.Local.ToBindingList();
        
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Debug.Print(Db.Tasks.Count().ToString());
            bindingSource1.EndEdit();
            Db.SaveChanges();
        }
