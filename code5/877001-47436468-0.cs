    string myname = "1234";
            string yourname = "12";
            char[] sam = new char[] { };
            sam = myname.ToCharArray();
            char[] sam1 = new char[] { };
            sam1 = yourname.ToCharArray();
            int id = 0;
            int id1 = 0;
            List<string> found = new List<string>();
            List<string> found1 = new List<string>();
            foreach (char item in sam)
            {
                if (found.Contains(item.ToString()))
                {
                    found.Add(item.ToString() + id);
                    id++;
                }
                else
                    found.Add(item.ToString());
            }
            foreach (var item in sam1)
            {
                if (found1.Contains(item.ToString()))
                {
                    found1.Add(item.ToString() + id);
                    id1++;
                }
                else
                    found1.Add(item.ToString());
            }
            var final = found.Except(found1);
            var final2 = found1.Except(found);
            var checkingCount = final.Count() + final2.Count();
            Console.Write(checkingCount);
            Console.ReadLine();
