      static List<string> getAvailablesRanges(List<int> data,int maxrange)
            {
                List<string> ranges = new List<string>();
                string last = null;
                foreach (int i in data)
                {
                    if (i == data.Max() && i != maxrange)
                    {
                        if (last != null) ranges.Add(last + "-" + i);
                        ranges.Add(i + "-" + maxrange);
                    }
                    else if (last == null)
                        last = i.ToString();
                    else
                    {
                        if(i-int.Parse(last)>1) ranges.Add(last + "-" + i);
                        last = null;
                    }
                }
                return ranges;
            }
