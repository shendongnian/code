    public class First_ViewModel:IChildLayout
    {
    public MainWindows_ViewModel Parent {get;set;}
    public ICommand cmdBtn1click{get;set;}
    private Pass_to_second_ViewModel()
    {
        //Here i change the Parent Child Property, it will switch to Second_View.xaml...
        this.Parent.Child=new Second_ViewModel();
    }
    public First_ViewModel()
    {
        // Here i connect the button to the command with Prism...
        this.cmdBtn1click=new DelegateCommand(()=>Pass_to_second_ViewModel());
    
    }
    #region INotifyPropertyChangedMembers...
