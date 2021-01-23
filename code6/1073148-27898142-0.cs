    public class Wrapper : INotifyPropertyChanged
    	{
    		List<Filiale> list;
    		JsonManager jM = new JsonManager ();//retrieve the list
    		public event PropertyChangedEventHandler PropertyChanged;
    		public NearMeViewModel ()
    		{
    			list = (jM.ReadData ()).OrderBy (x => x.distanza).ToList();//initialize the list
    		}
    
    		public List<Filiale> List{ //Property that will be used to get and set the item
    			get{ return list; }
    
    			set{ 
    				list = value;
    				if (PropertyChanged != null)
    				{
    					PropertyChanged(this, 
    						new PropertyChangedEventArgs("List"));// Throw!!
    				}
    			}
    		}
    
    		public void Reinitialize(){ // mymethod
    			List = (jM.ReadData ()).OrderBy (x => x.distanza).ToList();
    		}
