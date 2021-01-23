       public class GenerateReportsViewModel : CommonViewModelBase
            { 
        
               private string _parameterFileSelected;
                public string parameterFileSelected
                {
                    get { return _parameterFileSelected; }
                    set { SetValue(ref _parameterFileSelected, value); }
                }
                   get
    			{
    				return this.GetValue<string>();
    			}
    			set
    			{
    				this.SetValue(value);
    			}
        
                public void updateParameterFileSelected(string parameterFile)
                {
                    parameterFileSelected = parameterFile;
                }
        
             }
