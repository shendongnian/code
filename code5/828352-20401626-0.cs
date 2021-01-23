    int[] list1 = {1, 2, 3, 4, 5, 6};
    int[] list2 = {100, 101, 102};
    var total = list1.Count() + list2.Count();
    var skip = (list1.Count()/list2.Count())+1;
    var count1 = 0;
    var count2 = 0;
    var finalList = new List<int>();
    
    for (var i = 0; i < total; i++)
    {
        var count = i + 1;
        if (count % skip == 0)
        {
            finalList.Add(list2[count2]);
            count2++;
        }
        else
        {
            finalList.Add(list1[count1]);
            count1++;
        }
    }
    
    Console.WriteLine(String.Join(", ", finalList));
    Console.ReadKey();
