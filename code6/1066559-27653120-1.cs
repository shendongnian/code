    ServiceReference1.WebService1SoapClient client=new ServiceReference1.WebService1SoapClient();
    for (int i = 0; i < 7; i++)
    {
      t[i] = Convert.ToInt32(Console.ReadLine());
    }
    ServiceReference1.ArrayOfInt item = new ServiceReference1.ArrayOfInt();
    item.AddRange(t);
    ServiceReference1.ArrayOfInt result = client.bublesort(item);
    foreach (var i in result)
    {
      Console.WriteLine(i);
    }
