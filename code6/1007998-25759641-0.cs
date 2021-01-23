        private System.Collections.ObjectModel.ObservableCollection<vwGLAcct> gLAccounts;
        public System.Collections.ObjectModel.ObservableCollection<vwGLAcct> GLAccounts
        {
            get
            {
                return gLAccounts ?? (gLAccounts = new System.Collections.ObjectModel.ObservableCollection<vwGLAcct>());
            }
        }
    public CreateGLAcctsViewModel( )
    {
        this.SubmitCommand = new DelegateCommand(OnSubmit);
        // Populate ICollectionViews - i.e., properties...
        using (context = new TBLOADEntities())
        {
            // 3 properties behind ComboBoxes populated, then the DataGrid ppt...
            List<vwGLAcct> accts = new List<vwGLAcct>();
            accts.ForEach(a => this.GLAccounts.Add(a));
        }
    }
    private void OnSubmit()
    {
        GLAccount glAcct = new GLAccount()
        {
    // Various properties set, then...
            GlFsAcctTypeComboFK = this.SelectedFSAcctTypeComboID
        };
        using (context = new TBLOADEntities())
        {
    context.GlAcct.Add(glAcct);
    context.SaveChanges();
    // vwGLAcct is the EF entity of the MSSS db view...
    this.GLAccounts.Add(glAcct);
    }
 
