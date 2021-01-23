    SortedList<int, string> lista = new SortedList<int, string>();
    lista.Add(4, "Name");
    lista.Add(1, "Name");
    lista.Add(3, "Name");
    lista.Add(7, "Name");
    int nextID = 1;
    foreach (var item in lista.Keys)
    {
       if (nextID != item) break;
       else nextID++;
    }
    Console.WriteLine(nextID);
