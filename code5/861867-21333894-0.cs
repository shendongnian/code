    using (StreamReader sr = new StreamReader(@"D:\test1.txt"))
     {
          while (sr.Peek() >= 0)
          {
           //contents of foreach loop go here
           while ((line = sr.ReadLine()) != null)
                        {
           var items = line.Split(new[] { '\t', '\n' }).ToArray();
           if (items.Length != 3)
                        continue;
           var Name = items[0].ToString();
           var Email = items[1].ToString();
           var Pwd = items[2].ToString();
           cmd.CommandText = "insert into Employees values('" + Name + "','" + Email + "','" + Pwd + "')";
           cmd.CommandType = CommandType.Text;
           cmd.ExecuteNonQuery();
 
              }
      }
