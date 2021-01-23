    public ShellViewModel(IEnumerable<Screen> screens){
         //automatically finds what is in the IoC Container 
         //(MEF, SimpleContainer, AutoFac, StructureMap etc...
          this.Items.AddRange(screens);   
    }
    protected override OnInitialize(){
    }
<TabControl x:Name="Items">
        <TabControl.ItemTemplate>
            <DataTemplate>
                <TextBlock Text="{Binding DisplayName}" />
            </DataTemplate>
        </TabControl.ItemTemplate>
</TabControl>
The reason I do ```DisplayName``` it is already in Screen's class object as a property...  This way you don't have to do much extra work, coding out your ViewModels.
so...
public class ProjectViewModel : Screen{
     private Project _project;
     public ProjectViewModel(Project project){
       DisplayName = "Test" ;
       
       Project = project;
     }
     public Project Project{
        get{ return _project;}
        private set{
             _project = value;
             NotifyOfPropertyChange();
        }
     }
