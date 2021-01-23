            List<Tuple<int, DateTime, DateTime>> listA = new List<Tuple<int, DateTime, DateTime>>();
            listA.Add(new Tuple<int, DateTime, DateTime>(22, DateTime.Parse("09/01/2013 11:00"), DateTime.Parse("09/01/2013 12:00")));
            listA.Add(new Tuple<int, DateTime, DateTime>(66, DateTime.Parse("09/01/2013 12:01"), DateTime.Parse("09/01/2013 14:00")));
            List<Tuple<int, DateTime, DateTime>> listB = new List<Tuple<int, DateTime, DateTime>>();
            listB.Add(new Tuple<int, DateTime, DateTime>(33, DateTime.Parse("09/01/2013 11:30"), DateTime.Parse("09/01/2013 13:30")));
            List<Tuple<int, DateTime, DateTime>> listC = new List<Tuple<int, DateTime, DateTime>>();
            foreach (var rangeB in listB)
            {
                //a range in A overlaps with a range B 
                //if any end of the range in A is inside the range in B
                //consider using <= and/or >= in these two lines if needed
                var overlapping = listA.Where(rangeA => rangeB.Item2 < rangeA.Item2 && rangeA.Item2 < rangeB.Item3 ||
                    rangeB.Item2 < rangeA.Item3 && rangeA.Item3 < rangeB.Item3).ToList();
                overlapping = overlapping.Select(rangeA => 
                    new Tuple<int, DateTime, DateTime> (rangeB.Item1, 
                        //If a date of A is outside of B
                        //this will make it equal to the corresponding date of B
                        (rangeA.Item2 < rangeB.Item2) ? rangeB.Item2 : rangeA.Item2,
                        (rangeB.Item3 < rangeA.Item3) ? rangeB.Item3 : rangeA.Item3)).ToList();
                listC.AddRange(overlapping);
            }
