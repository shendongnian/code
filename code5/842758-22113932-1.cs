    FX db1 = new FX();
    LibraryManagementSystemEntities db2 = new LibraryManagementSystemEntities();
           
    Thread thread1 = new Thread(delegate()
    {
        db1.insert2(TextBox1.Text,TextBox2.Text);
        db2.insert1(TextBox1.Text,TextBox2.Text);
    });
    thread1.Start();
