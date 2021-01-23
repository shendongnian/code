        int id = 12;
        string rNameBoxText = "rName";
        DateTime dateBoxValue = DateTime.Now;
        string orderBoxText = "order";
        string[] orderDetails = { Convert.ToString(id + 1), rNameBoxText, dateBoxValue.ToString(), orderBoxText };
        //DEBUGGING
        Console.WriteLine(orderDetails[0]);
        Console.WriteLine(orderDetails[1]);
        Console.WriteLine(orderDetails[2]);
        Console.WriteLine(orderDetails[3]);
        //END DEBUGGING
        this.listView1.Columns.Clear();
        this.listView1.Columns.Add("Id");
        this.listView1.Columns.Add("rName");
        this.listView1.Columns.Add("Date");
        this.listView1.Columns.Add("Order");
        this.listView1.View = View.Details;
        //Add the order info to the ListView item on the main form
        var listViewItem = new ListViewItem(orderDetails);
        this.listView1.Items.Add(listViewItem);
