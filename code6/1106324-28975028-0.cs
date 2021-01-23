    using(var context = new DbContext())
    {
        // You could put a Where Clause here to limit the returns
        // i.e. context.ASMs.Where(s => s.Status == ASMStatus.IDLE).Load()
        context.ASMs.Load(); 
        var data = context.ASMs.Local.ToBindingList();
        var bs = new BindingSource();
        bs.DataSource = data;
        dataGridView1.DataSource = bs;
    }
