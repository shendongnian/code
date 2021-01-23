    BindingSource bs = new BindingSource();
    Purchasers.Add(new Purchaser { Name = "test", Paid = true });
    Purchasers.Add(new Purchaser { Name = "test1", Paid = true });
    Purchasers.Add(new Purchaser { Name = "test2", Paid = true });
    bs.DataSource = Purchasers;
    listBox1.DataSource = bs;
    listBox1.DisplayMember = "Name";
