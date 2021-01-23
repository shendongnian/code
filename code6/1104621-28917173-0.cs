    using System;
    using System.Data;
    using System.IO;
    
    namespace ConsoleApplicationTests
    {
        class Program
        {
            static int amount = 321370;
    
            static void Main(string[] args)
            {
                Coin[] c = new Coin[] { new Coin(500, 7), new Coin(200, 3), new Coin(100, 5) ,
                                        new Coin(50, 6), new Coin(20, 2), new Coin(10, 4),
                                        new Coin(5, 0), new Coin(2, 5), new Coin(1, 3)};
                int netAmount = amount;
                
                for (int i = 0; i < c.Length; i++)
                {
                    amount -= c[i].coveredPrice(amount);
                }
    
                for (int i = 0; i < c.Length; i++)
                {
                    Console.WriteLine(c[i].ToString());
                }
    
                Console.ReadLine();
    
            }
        }
    
        class Coin
        {
            private int price;
            private int counted;    // You can continue your bank for next amount too.
            private int maxNo;
    
            public Coin(int coinPrice, int coinMaxNo)
            {
                this.price = coinPrice;
                this.maxNo = coinMaxNo;
                this.counted = 0;
            }
    
            public int coveredPrice(int Price)
            {
                int Num = Price / price;
                if (maxNo == 0)
                    return 0;
                if (maxNo != -1)             //-i is infinit
                    if (Num > this.maxNo - this.counted)
                        Num = maxNo;
                this.counted += Num;
                return Num * price;
            }
            
            //public int getPrice() { return this.price; }
            //public int getCount() { return this.counted; }
            //public int getMax() { return this.maxNo; }
            public override string ToString()
            {
                return string.Format("{0} x {1} (max {2}) ", this.price.ToString(), this.counted.ToString(), this.maxNo.ToString());
            }
        }
    }
