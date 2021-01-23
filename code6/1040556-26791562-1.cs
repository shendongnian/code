           var list = new List<Object>();
           list.Add(new Object { Serie = 1 });
           list.Add(new Object { Serie = 2 });
           list.Add(new Object { Serie = 3 });
           list.RemoveAt(1);
           int i = 1;
           foreach (Object obj in list)
           {
               obj.Serie = i;
               i++;
           }
