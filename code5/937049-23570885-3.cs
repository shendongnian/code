    public void Insert(){
        if(_view.Type == "Loan"){
           var model = new LoanRecovery();
           model.IssueDate = _view.IssueDate;
           model.Amount = _view.Amount;
           _dataService.InsertLoan(model);
        }
    }
