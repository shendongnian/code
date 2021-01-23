    //View Models
    public class SimpleViewModel
    {
      public ICommand SearchTreeCommand {get;set;}
    }
    //View 1 with a DataContext of new SimpleViewModel { SearchTreeCommand = new FirstImplementationOfSearchTreeCommand() }
    <Button Command="{Binding SearchTreeCommand}" Content="Next"/>    
    //View 2 with a DataContext = new SimpleViewModel { SearchTreeCommand = new SecondImplementationOfSearchTreeCommand() }
     <Button Command="{Binding SearchTreeCommand}" Content="Next"/>
