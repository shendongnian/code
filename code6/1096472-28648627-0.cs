    for (int i= 0; i < list.Count; i++)
       {
          for (int j = i + 1; j < list.Count; j++)
            {
               if (list[i] == list[j])
                 {
                    adjacent_found = true;
                    count++;
                 }
            }
       }
