public interface IPlugin
{
    void Execute();
    event EventHandler OnExecute;
}
public class Sum : IPlugin
{
    public void Execute()
    {
       if (this.OnExecute != null)
           this.OnExecute(this, new EventArgs());
    }
    public event EventHandler OnExecute;
}
////////// use
Sum sum = new Sum();
Console.WriteLine("Before subscribe");
sum.Execute();
sum.OnExecute += new EventHandler(sum_OnExecute);
Console.WriteLine("After subscribe");
sum.Execute();
