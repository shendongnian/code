    using System;
    
    public class Test
    {
    	public static void Main()
    	{
    		// your code goes here
    		InvitationalSurvey iservey = new InvitationalSurvey();
    		iservey.DoSomething(1, 1, 1);
    		iservey.DoSomething(1);
    	}
    }
    
    public abstract class BaseSurvey
    {
         
    }
    public class InvitationalSurvey: BaseSurvey
    {
    	public void DoSomething(int param1, int param2 = 0, int param3 = 0)
        {
        //I don't need param2 and param3 here
        Console.WriteLine(string.Format("{0},{1},{2}",param1, param2, param3));
        }
    }
