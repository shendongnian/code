    ViewModel
    {
       private Loan _loan;
       public Loan loan; 
       { 
            get { return _loan; }
            set 
            { 
                _loan = value;
                _loan.PropertyChanged += NotifiyLoanChanged;
            }
        }
    
        void NotifyLoanChanged(object sender, EventArgs e) 
        {
            // invoke my events to ViewModel listners
            notifypropertychanged(e.PropertyName);
        }
    }
