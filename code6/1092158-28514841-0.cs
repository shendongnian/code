    int start, end;
    
    String a = "{item1}, {item2} (2), {item3}    (4),  {item4}(1), {item5},{item6}(5)";
    
    string[] b = a.Split(',');
    
    foreach (String item in b)
    {
         Console.WriteLine(item);
    
         start=item.IndexOf('{') +1 ;
         end = item.IndexOf('}') -1 ;
         Console.WriteLine(" \t Name : " + item.Substring(start,end-start));
                    
          if (item.IndexOf('(')!=-1 )
          {
    
               start = item.IndexOf('(');
    
               Console.WriteLine(" \t Count : " + item[start+1] );
           }
                     
     }
