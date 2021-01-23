    foreach(var group in query)
    {
       using (var writer = File.CreateText(group.FileName))
       {
           foreach(var item in group)
                writer.WriteLine(String.Format("{0} {1} {2}",
                                 item.Value1, item.Value2, item.Value3));
       }
    }
