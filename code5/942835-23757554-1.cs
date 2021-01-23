            List<int> query = Enumerable.Range(0, 1440).Select((n, index) =>
            {
                if ((index >= 525 && index <= 544) || (index >= 600 && index <= 749) || (index >= 810 && index <= 1079) || (index >= 1300 && index <= 1439))
                    return 0;
                else if (index >= 1080 && index <= 1299)
                    return 1;
                else if (index >= 545 && index <= 599)
                    return 3;
                else if (index >= 750 && index <= 809)
                    return 4;
                else
                    return 2;
            }).ToList();
            Console.WriteLine(string.Concat("{", string.Join(",", query.ToArray()), "}"));
            List<int> lst2 = Enumerable.Range(0, 1440).Select((n, index) =>
            {
                if (query[index] == 1 || query[index] == 2)
                    return 1;
                else if (query[index] == 3 || query[index] == 4)
                    return 0;
                else
                {
                    int retval = 1;
                    //look ahead
                    for (int i = index; i < query.Count; i++)
                    {
                        if (query[i] == 1 || query[i] == 2)
                        {
                            break;
                        }
                        if (query[i] == 3 || query[i] == 4)
                        {
                            retval = 0;
                            break;
                        }
                    }
                    return retval;
                }
            }).ToList();
            Console.WriteLine(string.Concat("{", string.Join(",", lst2.ToArray()), "}"));
