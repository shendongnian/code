    List<Orders> orders = new List<Orders>();
    private void UpdateCache(List<int> idList)
    {
        using (var db = new Test(Settings.Default.testConnectionString))
        {
            DataLoadOptions opt = new DataLoadOptions();
            opt.LoadWith<Orders>(x => x.Suborders);
            db.LoadOptions = opt;
            orders = db.Orders.Where(x => idList.Contains(x.Id)).ToList();
        }
    }
    private void DumpOrders()
    {
        foreach (var order in orders)
        {
            Console.WriteLine("*** order");
            Console.WriteLine("id:{0},name:{1}", order.Id, order.Name);
            if (order.Suborders.Any())
            {
                Console.WriteLine("****** sub order");
                foreach (var suborder in order.Suborders)
                {
                    Console.WriteLine("\torder id:{0},id{1},name:{2}", suborder.Order_id, suborder.Id, suborder.Name);
                }
            }
        }
    }
    private void button1_Click(object sender, EventArgs e)
    {
        UpdateCache(new List<int> { 0, 1, 2 });
        DumpOrders();
    }
