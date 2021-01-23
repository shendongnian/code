    public class Employer : INotifyPropertyChanged
    {  
    	private string nameField;
    	public string Name {
    		get { return nameField; }
    		set {
    			nameField= value;
    			if (PropertyChanged != null) {
    				PropertyChanged(this, new PropertyChangedEventArgs("Name"));
    			}
    		}
    	}
    
    	private int idField;
    	public int Id {
    		get { return idField; }
    		set {
    			idField= value;
    			if (PropertyChanged != null) {
    				PropertyChanged(this, new PropertyChangedEventArgs("Id"));
    			}
    		}
    	}
    
    	public event PropertyChangedEventHandler PropertyChanged;
    }
