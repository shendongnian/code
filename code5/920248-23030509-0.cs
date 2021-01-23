    MyList m = new MyList();
    m.Add("n1", DateTime.Now);
    m.Add("n2", DateTime.Now.AddDays(1));
    m.Add("n3", DateTime.Now.AddDays(-1));
    var sortedList = from i in m
        orderby i.expires
        select i;
    listBox1.Items.AddRange(sortedList.ToArray());
