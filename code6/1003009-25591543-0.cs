    string s = string.Format("There are {0} items, bla bla {1}",
                itemsCnt,
                new Func<string>(() =>
                {
                    switch (itemsCnt)
                    {
                        case 0:
                            return "make some...";
                        case 1:
                        case 2:
                            return "try more";
                        default:
                            return "enough";
                    }
                })()
                );
