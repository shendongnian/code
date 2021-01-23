    using System;
    public class Program {
	public void Main()
    {
		int sum=0,d;
		string  oNum  =  "79927398713";
		
		int  a  =  0;
		for(int  i  =  oNum.Length-2;  i>=0;i--)
		{
			d  =  Convert.ToInt32(oNum.Substring(i,1));
			if  (a  %  2  ==  0)  d  =  d*2;
			if  (d  >  9)  d  -=  9;
			sum  +=  d;
			a++;
		}
		
		if  ((10  -  (sum%10))  ==  Convert.ToInt32(oNum.Substring(oNum.Length-1)))
		{
			Console.WriteLine("Valid");
		}
        else
    {
    Console.WriteLine("Invalid");
    }
		Console.WriteLine("sum of digits of the number:" + sum);
        }
    }
