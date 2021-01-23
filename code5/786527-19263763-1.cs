    var cust = new List<Table>
                           {
                               new Table {Conversation = 1, Id = 1, User = "Bob"},
                               new Table {Conversation = 1, Id = 2, User = "Jane"},
                               new Table {Conversation = 2, Id = 3, User = "Tim"},
                               new Table {Conversation = 2, Id = 4, User = "Lily"},
                               new Table {Conversation = 2, Id = 5, User = "Rick"}
                           };
            var names = new List<string> { "Rick", "Lily", "Tim" };
          
            var res = from x in cust
                      group x by x.Conversation
                      into y
                      where y.Select(z => z.User).Intersect(names).Count() == names.Count
                      select y.Key;
