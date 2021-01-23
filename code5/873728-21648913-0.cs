         var list1 = Enumerable.Intersect(listBox1.Items.Cast<string>().ToArray(), listBox2.Items.Cast<string>().ToArray());
           for (int i = 0; i < listBox1.Items.Count; i++)
           {
               if (list1.Contains(listBox1.Items[i]))
               {
                
                   listBox1.SetSelected(i, true);
                   listMatchedItems.Items.Add(listBox1.Items[i]).ToString();
               }
               else
               {
                   listNotMatchedItems.Items.Add(listBox1.Items[i]).ToString();
               }
             
           }
        var list2 = Enumerable.Intersect(listBox2.Items.Cast<string>().ToArray(), listBox1.Items.Cast<string>().ToArray());
           for (int i = 0; i < listBox2.Items.Count; i++)
           {
               if (list2.Contains(listBox2.Items[i]))
               {
                   int a = i + 1;
                   listBox2.SetSelected(i, true);
               }
               else
               {
               }
               }
