    namespace ApplicationName.DataSetNameTableAdapters
    {
        public partial class BarTableAdapter 
        {
            public bool ContinueUpdateOnError
            {
                get
                {
                    return this.Adapter.ContinueUpdateOnError;
                }
                set
                {
                    this.Adapter.ContinueUpdateOnError = value;
                }
            }
        }
    }
