            var bugquery = from c in list2
                            group c by c.bugid into x
                            select new bug { bugid = x.Key, list1 = x.SelectMany(l => l.list1).Distinct().ToList() };
            foreach (bug bug in bugquery)
            {
                StringBuilder files = new StringBuilder();
                files.Append(bug.bugid);
                files.Append("\t");
                files.Append(string.Join("\t", bug.list1.ToArray()));
                file.WriteLine(files.ToString());
            }
