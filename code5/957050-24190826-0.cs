    public class DataTableEx : DataTable
        {
            public bool fwHasData
            {
                get
                {
                    return (Rows.Count == 0) ? true : false;
                }
            }
        }
