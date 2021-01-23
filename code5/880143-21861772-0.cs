    public class SystemAccount
    {
        public int ID { get; set; }
        public int? MasterAccountID { get; set; }
        public int? SecondMasterAccountID { get; set; }
        public virtual SystemAccount MasterAccount { get; set; }
        public virtual SystemAccount SecondMasterAccount { get; set; }
        public virtual List<SystemAccount> AllSubAccounts { get; set; }
        public virtual List<SystemAccount> SecondarySubAccounts { get; set; }
    }
