            List <bug> bugs = new List<bug>();
            var lines = System.IO.File.ReadLines(@"/home/bugs");
            foreach (var line in lines) {
                string[] items = line.Split('\t');
                bug bg=new bug();
                bg.bugid = items[0];
                bg.list1 = items.Skip(1).OrderBy(f => f).Distinct().ToList();
                bugs.Add(bg);
                }
