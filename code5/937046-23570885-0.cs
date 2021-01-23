    interface IBaseRecover{
        void Save();
        ....
    }
    class LoanRecovery : IBaseRecover {
        private IDataService _dataService;
        LoadRecovery(IDataService dataService){
            _dataService = dataService;
        }}
        void Save(){
           _dataService.InsertLoan(this);
        }
    }
