    class clsPurchaseOrderList : INotifyPropertyChanged, IDataErrorInfo
    {
        private int _Product_Id;
        public int Product_Id
        {
            get { return _Product_Id; }
            set
            {
                _Product_Id = value;
                OnPropertyChanged("Product_Id");
            }
        }
    
         private ObservableCollection<PanelDC> testCollection;
            public ObservableCollection<PanelDC> TestCollection
            {
                get
                {
                    return this.testCollection;
                }
            }
    
            public void GetProducts()
            {            
                DataSet ds = new DataSet();
                string qry = "select PM.Record_Id as Product_Id,PM.Product_Code,PM.Product_Name,PTM.Product_Type from dbo.Tbl_Product_Master PM join dbo.Tbl_Product_Type_Master PTM on PTM.Record_Id=PM.Product_Category_Id where PM.Is_Del=0 and PM.Is_Active=1";
                ds = ObjCommon.GetObject.ExecuteQuery_Select(Connection.ConnectionString, qry);
                
                DataTable testTable = new DataTable();
                testTable = ds.Tables[0];
    
                testCollection = new ObservableCollection<PanelDC>();
    
                foreach(DataRow row in testTable.Rows)
                {
                    var obj = new PanelDC()
                    {
                        PanelName = (string)row["PanelName"],
                        PanelNo = (int)row["PanelNo"]
                    };
                    testCollection.Add(obj);
                }
    
                this.OnPropertyChanged("TestCollection");
            }
    }
