    using System.Collections.Generic;
    using System.Linq;
    
    namespace ConsoleApp1
    {
        class Program
        {
            static void Main(string[] args)
            {
                var accountVouchers= new List<AccountVoucher>
                {
                    new AccountVoucher{ Debit=125, Credit=0},
                    new AccountVoucher{ Debit=236,Credit=0},
                    new AccountVoucher{ Debit=0, Credit=100},
                };
                var result=accountVouchers.Select((x, i) => new AccountVoucher { Debit = x.Debit, Credit = x.Credit, Balance = list.Take(i+1).Sum(y => y.Debit - y.Credit) });
            }
        }
        class AccountVoucher
        {
            public int Debit { get; set; }
            public int Credit { get; set; }
            public int Balance { get; set; }
        }
    }
