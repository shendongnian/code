    public class AnItemToList
    {
       public AnItemToList(Action commandDel)
       {
            TestCommand = new RelayCommand(commandDel);
       }
       public string Name { get; set; }
       public RelayCommand TestCommand { get; set; }
    }
