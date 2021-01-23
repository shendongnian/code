    string[] a = new string[] { "10", "22", "9", "33", "21", "50", "41", "60", "80" };
            List<int> res = new List<int>();
            int arrLength = a.Length;
            int i = 0;
            for (i = 0; i < arrLength; i++)
            {
                if (i < arrLength)
                {
                    if (res.Count != 0)
                    {
                        if (Convert.ToInt32(a[i]) > res[res.Count - 1])
                        {
                            res.Add(Convert.ToInt32(a[i]));
                        }
                    }
                    else
                    {
                        res.Add(Convert.ToInt32(a[i]));
                    }
                }
            }
    
            int asdf = res.Count;
