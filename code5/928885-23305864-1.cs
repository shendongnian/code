    using System;
    
    public class Test
    {
    	public static void Main()
    	{
            double[] coins = {0.05,0.10,0.20,0.50,1.00,1.42,2.00};
    
            Console.WriteLine("Change is as follows:");
            
            for (int j = 0; j < coins.Length; j++)
            {
            	var amount = coins[j];
            	var dollars = Math.Floor(amount);
            	var change = amount - dollars;
            	var cents = 100*change;
            	
                string ds = dollars == 1 ? String.Empty : "s";
            	string cs = cents == 1 ? String.Empty : "s";
    
            	if (amount >= 0 && amount < 1)
            	{
            		Console.WriteLine("{0} cents", cents);
            	}
            	else if (dollars >= 1 && cents == 0)
            	{
            		Console.WriteLine("{0} dollar{1}", dollars, ds);
            	}
            	else
            	{
            		Console.WriteLine("{0} dollar{1} and {2} cent{3}",
            			dollars, ds, cents, cs);
            	}
            }
    	}
    }
