            string[] hnames = names.ToArray(typeof(string)) as string[];
            string[] hvals = values.ToArray(typeof(string)) as string[];
            
            string postData = string.Empty;
            bool isFirst = true;
            int i = 0;
            /* Assumption - Both arrays hnames and hvals are of same length.
                            Otherwise you'll get the same error if hvals.Length < hnames.Length even if you use the foreach
             */
            foreach (string hname in hnames)
            {
                if (isFirst)
                {
                    postData = hname + "=" + hvals[i] + "&"; //IndexOutOfRangeException here
                    isFirst = false;
                }
                else
                {
                    postData += hname + "=" + hvals[i];
                }
                i++;
            }
