    //Generated code
    public partial class Account{
        public List<AccountInfo> GeneratedAccountInfos { get; set; }
        //other fields
    }
    //My code
    public partial class Account : SomeAccountInterface{
        public int ID {get; set;}
        //Correct name to implement AccountInfos property of SomeAccountInterface
        public virtual List<AccountInfo> AccountInfos {get; set;} 
        List<SomeAccountInfoInterface> SomeAccountInterface.AccountInfos{
             get{ return AccountInfos; }
        }
    }
    public partial class AccountInfo{
         //some generated fiels
    }
    public partial class AccountInfo : SomeAccountInfoInterface{
        public virtual Account {get; set;}
        [ForeignKey("Account")]
        public int AccountID {get; set;}
    }
