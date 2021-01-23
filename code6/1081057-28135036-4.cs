    var connectionString = "mongodb://localhost";
    var client = new MongoClient(connectionString);
    var server = client.GetServer();
    var database = server.GetDatabase("testdb1");
    var collection = database.GetCollection<Entity>("tablo1");
    //var entity = collection.FindAll();
    BindingList<Entity> doclist = new BindingList<Entity>();
    foreach (var deger in collection.FindAll())
    {
        doclist.Add(deger);
        //string[] row1 = new string[] { deger.deger1.ToString() };
        //dataGridView1.Rows.Add(row1);
        Application.DoEvents();
    }
    dataGridView1.DataSource = doclist;
