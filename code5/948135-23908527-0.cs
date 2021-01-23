    public class ViewModel
    {
    	public ObservableCollection<Employee> List { get; set; }
    
    	public ViewModel()
    	{
    		List = new ObservableCollection<Employee>();
    		List.Add("Select");
    		List.Add("Add New");
    
    		foreach (var employee in LstEmployeeDetails.OrderBy(e => e.EmployeeName))
    		{
    			List.Add(employee);
    		}
    	}
    }
    <ComboBox x:Name="CmbboxEmployeeName" ItemsSource="{Binding List}"/>
