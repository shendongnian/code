            List<TestItem> list = new List<TestItem>()
            {
                new TestItem() { ID = 1, Weight = 30 },
                new TestItem() { ID = 2, Weight = 40 },
                new TestItem() { ID = 3, Weight = 50 },
                new TestItem() { ID = 4, Weight = 60 },
                new TestItem() { ID = 5, Weight = 70 },
            };
            int sum = 0, limit = 100;
            var grouping = list.GroupBy(x => 
            {
                // check whether grouping new item will exceed the limit or not
                if (sum + x.Weight > limit) 
                { 
                    return 1; 
                } 
                else 
                {
                    // it is important to keep track of `sum` here
                    sum += x.Weight; 
                    return 0; 
                } 
            });
            foreach (var group in grouping)
            {
                 if(group.Key == 0) {
                     // this group contains Weigth 30 & 40
                 } else if(group.Key == 1) {
                     // this group cintains Weight 50 & 60 & 70
                 }
            }
