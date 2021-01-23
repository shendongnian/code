    public sealed class MainViewModel : INotifyPropertyChanged
    {
    	public ObservableCollection<StudentViewModel> Students {get; set;}
    }
    
    public sealed class StudentViewModel : INotifyPropertyChanged
    {
    	public ObservableCollection<GradeViewModel> Grades {get; set;}
    	
    	public StudentViewModel(){
    		Grades = new ObservableCollection<GradeViewModel>();
    	}
    }
    
    public sealed class GradeViewModel : INotifyPropertyChanged
    {
    	public string Name { get; set; }
    	public int Value { get; set; }
    }
