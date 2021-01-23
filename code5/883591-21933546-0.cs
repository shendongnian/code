    using System;
    
    public class Test
    {
    	static void DoubleTest(double value)
    	{
    		var binary = BitConverter.DoubleToInt64Bits(value);
    		binary++;
    		var newValue = BitConverter.Int64BitsToDouble(binary);
    		var difference = newValue - value;
    		Console.WriteLine("value  = {0:R}", value);
    		Console.WriteLine("value' = {0:R}", newValue);
    		Console.WriteLine("dx     = {0:R}", difference);
    		Console.WriteLine();
    	}
    	public static void Main()
    	{
    		DoubleTest(0.0000000004);
    		DoubleTest(4.0000000000);
    		DoubleTest(4000000000.0);
    	}
    }
