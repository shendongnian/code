    public class MyDataModel
    {
        // Do not show in data grid view
        [System.ComponentModel.Browsable(false)]
        public virtual int ID { get; protected set; }
        // Set to read-only in data grid view
        [System.ComponentModel.ReadOnly(true)]
        public virtual string Person { get; set; }
    }
