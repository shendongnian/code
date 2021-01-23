            using (System.IO.StreamReader reader1 = new System.IO.StreamReader(@"/home/sunshine40270/mine/projects/interaction2/fasil-data/common history/outputpure"))
            {
                string line1;
                while ((line1 = reader1.ReadLine()) != null)
                {
                    if (!string.IsNullOrWhiteSpace(line1))
                    {
                        string[] items1 = line1.Split(new [] { '\t' }, StringSplitOptions.RemoveEmptyEntries);
                        bug bg = new bug();
                        bg.bugid = items1[0];
                        for (int i = 1; i <= items1.Length - 1; i++)
                        {
                            bg.list1.Add(items1[i]);
                        }
                        list2.Add(bg);
                    }
                }
            }
