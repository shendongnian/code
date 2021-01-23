    public void Insert(){
        if(_view.Type == "Loan"){
           var model = new LoadRecovery();
           model.IssueDate = _view.IssueDate;
           model.Amount = _view.Amount;
           _dataService.InsertLoan(model);
        }
    }
    
