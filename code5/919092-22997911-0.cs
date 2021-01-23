     List<T> list1 = new List<T> { new T { key = 1, a = 10, b = 10, c = 10 }, new T { key = 2, a = 10, b = 10, c = 10 }, new T { key = 3, a = 10, b = 10, c = 10 } };
     List<T> list2 = new List<T> { new T { key = 1, a = 10, b = 10, c = 99 }, new T { key = 2, a = 11, b = 10, c = 10 }, new T { key = 4, a = 10, b = 10, c = 10 } };
     List<int> difference = new List<int>();
     foreach (var item2 in list2)
     {
         var item1 = list1.FirstOrDefault(i => i.key == item2.key);
                
         if (item1 != null)
         {
             if (item2.a == item1.a && item2.b == item1.b)
                 continue;
         }           
         difference.Add(item2.key);
     }
