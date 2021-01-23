    public class MathOperationUI
    {
    	MathOperations usersMathOperations;
    	public MathOperationUI()
    	{
    		usersMathOperations = new MathOperations();
    	}
    
    	public void MathMainModule()
    	{
    		DisplayMenu();
    		usersMathOperations.FirstOperand = PromptForInterger("first");
    		usersMathOperations.SecondOperand = PromptForInterger("second");
    		Console.WriteLine("\n\nEnter your coice");
    		ProcessMenu(int.Parse(Console.ReadLine()));
    	}
