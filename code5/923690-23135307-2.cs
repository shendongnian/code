    //viewmodel
    public class ProgramViewModel
    {
    	public ObservableCollection<Program> Programs { get; set; }
    	
    	public ProgramViewModel()
    	{
    		Programs = new ObservableCollection<Program>(getAllPrograms());
    	}
    	
    	public List<Program> getAllPrograms()
    	{
    		List<Program> programs = new List<Program>();
    		Program p1 = new Program();
    		p1.SerialNumber= "ss0";
    		p1.FirstName = "ss1";
    		p1.LastName= "ss1L";
    		Program p2 = new Program();
    		p2.SerialNumber= "Program 2";
    		p2.FirstName = "ss1";
    		p2.LastName= "ss2L";
    		programs.Add(p1);
    		programs.Add(p2);
    		return programs;
    	}
    }
    
    //model
    public class Program
    {
    	public string SerialNumber { get; set; }
    	public string FirstName { get; set; }
    	public string LastName { get; set; }
    }
    
    //view
    <Page.Resources>
        <vm:ProgramViewModel x:Key="ProgramViewModel"/>
    </Page.Resources>
    <Grid>
    	<data:DataGrid Grid.Row="0" x:Name="gridPrograms" AutoGenerateColumns="False" 
    			   ItemsSource="{Binding Programs}" IsReadOnly="True"  
    			   DataContext="{StaticResource ProgramViewModel}" >
    		<data:DataGrid.Columns>
    			<data:DataGridTextColumn Header="SerialNumber" Binding="{Binding SerialNumber}" Width="2*"></data:DataGridTextColumn>
    			<data:DataGridTextColumn Header="FirstName" Binding="{Binding FirstName}" Width="2*"></data:DataGridTextColumn>
    			<data:DataGridTextColumn Header="LastName" Binding="{Binding LastName}" Width="3*"></data:DataGridTextColumn>               
    		</data:DataGrid.Columns>
    	</data:DataGrid>
    </Grid>
