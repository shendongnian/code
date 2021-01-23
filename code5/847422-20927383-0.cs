    public class Program
    {
    	public void Main()
        {
    		int answer = GetAnswer(4); //4 is the argument
            //don't do `GetAnswer()`;
    		Console.WriteLine(answer);
        }
    	
    	public static int GetAnswer(int num)
    	{
    		return (num*0) + 42;
    	}
    }
