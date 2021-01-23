    internal class MyClass
    {
        private ApiObject apiObject;
    
        public event EventHandler Initialized;
     
        internal MyClass()
        {
            this.apiObject = new ApiObject();
        }
        
        public void Initialize()
        {
            this.apiObject.ApiStateUpdate += delegate(string who, int howMuch) 
            {
                var cond1 = false;
                var cond2 = false;
            
                if(who.Equals("Something") && howMuch == 1)
                    cond1 = true;
                else if(who.Equals("SomethingElse") && howMuch == 1)
                    cond2 = true;        	
    
                //wait for both conditions to be true
    		
                if ( !cond1 && !cond2 )
                    return;
    	
                // fire an event when both conditions are met
                if (this.Initialized != null)
                    this.Initialized(this, new EventArgs());
            };
        }
    }
