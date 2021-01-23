            ArrayList lkl = serl.ListLookupsC(0);
            if (lkl.Count > 1)
            {
                LookUpCollection_6.Clear();
                LookUpCollection_7.Clear();
                for (int x = 0; x < lkl.Count; x++)
                {
                    string[] strLData = (string[])lkl[x];
                    PCodeList.Add(x, strLData[1]);
                }
            }
