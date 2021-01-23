        private void GetSalesAgents()
        {
            this.Cursor = Cursors.Wait;
            SerUsers seru = new SerUsers();
            ArrayList al = seru.GetTeleSales();
            _SalesAgentList.Clear();
            if (al.Count == 0)
            {
                this.Cursor = Cursors.Arrow;
                return;
            }
            for (int x = 0; x < al.Count; x++)
            {
                string[] strData = (string[])al[x];
                int nIndex = -1;
                // Use LINQ to find the key for the value
                if (strData[2].Length == 2)
                {
                    var item = (from d in PCodeList
                                where d.Value.Substring(0, 2) == strData[2]
                                select d.Key).FirstOrDefault();
                    nIndex = (int)item;
                }
                _SalesAgentList.Add(new SalesAgentRec{
                    MCUid = strData[0],
                    MCName = strData[1],
                    MCPostCode = strData[2],
                    MCCodes = PCodeList,
                    MCPostCodeX = nIndex,
                    MCSIndex = x.ToString()
                });
            }
            this.manage_calls_listView.View = this.manage_calls_listView.FindResource("manage_calls_gridView") as ViewBase;
            this.Cursor = Cursors.Arrow;
        }
