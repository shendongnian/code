    //View 1 with a DataContext of new SimpleViewModel { SearchTreeCommand = new FirstImplementationOfSearchTreeCommand() }
    <Button Command="{Binding SearchTreeCommand}" Content="Next"/>    
    //View 2 with a DataContext = new ComplicatedViewModel { SearchTreeCommand = new SecondImplementationOfSearchTreeCommand() }
     <Button Command="{Binding SearchTreeCommand}" Content="Next"/>
    //View Models
    ///<remarks>Notice I don't implement from anything shared with the SimpleView, no interface</remarks>
    public class ComplicatedViewModel
    {
      public ICommand SearchTreeCommand {get;set;}
      //I have other stuff too ;-)
    }
