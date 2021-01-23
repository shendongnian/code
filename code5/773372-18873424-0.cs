    public double first {get;set;}
    public double second {get;set;}
    
    public DelegateCommand DivideCommand{get;set;}
    public class1()
    {
         DivideCommand = new DelegateCommand(this.Divide)
    }
    private void Divide(object parameter)
    {
        first/=2;
        second/=2;
    }
