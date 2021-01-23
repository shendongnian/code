    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace Payments
    {
        class Program
        {
            static void Main(string[] args)
            {
                Payment p1 = new Payment();
                Payment p2 = new Payment();
                Payment p3 = new Payment();
    
                Payment Sorted = SortPayments(p1, p2, p3);
            }
    
            static private Payment SortPayments(params Payment[] payments)
            {
                if(payments.Length == 0)
                {
                   return null;
                }
                Payment FirstPayment = payments[0];
    
                Payment current = FirstPayment;
                for (int i = 1; i < payments.Length; i++ )
                {
                    current.SupplementalPayment = payments[i];
                    current = current.SupplementalPayment;
                }
    
                return FirstPayment;
            }
        }
    }
