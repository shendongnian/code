    public class CustomMsSql2008Dialect : MsSql2008Dialect
            {
                public override string PrimaryKeyString
                {
                    get { return "primary key nonclustered"; }
                }           
              
            }
