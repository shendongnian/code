            if (reader.Read())
            {
                Mb mb = new Mb();
                mb.Id = reader.GetSafe<int>("Id");
                mb.Mem_NA = reader.GetSafe<string>("Mem_NA");
                mb.Mem_ResAdd4 = reader.GetSafe<string>("Mem_ResAdd4");
                mb.Mem_ResPin = reader.GetSafe<int>("ResPin");
            }
