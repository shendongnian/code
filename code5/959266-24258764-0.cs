            const int groupSize = 4;
            var items = new []{1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25};
            
            var currentGroupIndex=-1;
            var step1 = items.Select(a =>{
                if (++currentGroupIndex >= groupSize)
                    currentGroupIndex = 0;
                return new {Group = currentGroupIndex, Value = a};
            }).ToArray();
            
            var step2 = step1.GroupBy(a => a.Group).Select(a => a.ToArray()).ToArray();
            var group1 = step2[0].Select(a => a.Value).ToArray();
            var group2 = step2[1].Select(a => a.Value).ToArray();
            var group3 = step2[2].Select(a => a.Value).ToArray();
            var group4 = step2[3].Select(a => a.Value).ToArray();
