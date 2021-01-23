    using (StringReader reader = new StringReader(data))
        {
            string line = "";
            int counter = 0;
            while ((line = reader.ReadLine()) != null)
            {
                c = new table1();
                c.Code = line.Substring(0, 5).Trim();
                c.name= line.Substring(5, 18).Trim();
                c.phone= line.Substring(23, 16).Trim();
                c.address = line.Substring(39, 20).Trim();
                context.table1.Add(c);
                if (counter == 10){
                  context.SaveChanges();
                  counter =0;
               }
               else{
                  counter++;
               }
            }
            context.SaveChanges();
        }
