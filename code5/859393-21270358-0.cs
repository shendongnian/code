    static int main(){
    
    	int num1 = 7;
    	int num2 = 1;
    	int num3 = 3;
    
    	string strNum1 = string.Concat(num2.ToString(), num1.ToString());
    	string strNum2 = string.Concat(num3.ToString(), num2.ToString(), num1.ToString());
    	int newNumber1 = int.Parse(strNum1);
    	int newNumber2 = int.Parse(strNum2);
    	
    	Console.WriteLine(IsPrime(num1)); // True
    	Console.WriteLine(IsPrime(newNumber1)); // True
    	Console.WriteLine(IsPrime(newNumber2)); // True
    }
    
    
    /// <summary>
    /// Used to determine if number is a prime number
    /// </summary>
    /// <param name="value">The whole number.</param>
    /// <returns></returns>
    public static bool IsPrime(int value)
    {
    	if (value == 1)
    	{
    		return true;
    	}
    	else if ((value & 1) == 0)
    	{
    		if (value == 2)
    			return true;
    		else
    			return false;
    	}
    
    	for (int i = 3; (i * i) <= value; i += 2)
    	{
    		if ((value % i) == 0)
    			return false;
    	}
    	return value != 1;
    }
