         SortedList<int, string> sortedlist = new SortedList<int, string>();
                //add the elements in sortedlist
                sortedlist.Add(1, "Sunday");
                sortedlist.Add(2, "Monday");
                sortedlist.Add(3, "Tuesday");
                sortedlist.Add(4, "Wednesday");
                sortedlist.Add(5, "Thusday");
                sortedlist.Add(6, "Friday");
                sortedlist.Add(7, "Saturday");
                //display the elements of the sortedlist
                Console.WriteLine("The elements in the SortedList are:");
                foreach (KeyValuePair<int, string> pair in sortedlist)
                {
                    Console.WriteLine("{0} => {1}", pair.Key, pair.Value);
                }
                var orderByVal = sortedlist.OrderBy(v => v.Value);
                //display the elements of the sortedlist after sorting it with Value's
                Console.WriteLine("The elements in the SortedList after sorting :");
                foreach (KeyValuePair<int, string> pair in orderByVal)
                {
                    Console.WriteLine("{0} => {1}", pair.Key, pair.Value);
                }
