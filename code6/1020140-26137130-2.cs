    namespace ApplicationName.DataSetNameTableAdapters
    {
        public partial class BarTableAdapter 
        {
            public bool ContinueUpdateOnError
            {
                get
                {
                    return this._adapter.ContinueUpdateOnError;
                }
                set
                {
                    this._adapter.ContinueUpdateOnError = value;
                }
            }
        }
    }
