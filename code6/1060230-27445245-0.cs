        private void TestDgvFilter()
        {
            DataGrid DG = new DataGrid();
            DG.Items.Filter = new Predicate<object>(Filter);
        }
        private bool Filter(object t)
        {
            DataItem d = t as DataItem;
            return (d.Challan_No == "2014CH 10026");
        }
        /// <summary>
        /// Class that represents your data grid row items
        /// </summary>
        private class DataItem
        {
            public string Id;
            public string Challan_No;
            public string Organization;
            public string Organization_Name;
            public string Date;
        }
