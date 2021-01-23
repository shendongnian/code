                   private string _parameterFileSelected;
                    public string parameterFileSelected
                    {
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
