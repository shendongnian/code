     using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Test\yourFile.csv"))
     {
       file.WriteLine("name,age");
       foreach(var item in data)
       {
          file.WriteLine(String.Format("{0},{1}", item.name, item.age));
       }
     }
