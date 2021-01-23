    [InverseProperty( "MasterAccount" )]
    public virtual List<SystemAccount> AllSubAccounts { get; set; }
    
    [InverseProperty( "SecondMasterAccount" )]
    public virtual List<SystemAccount> SecondarySubAccounts { get; set; }
