        public abstract class BasePage : Page    
        {    
            protected override void OnLoad(EventArgs e)    
            {    
                //Handling autocomplete issue generically    
                if (this.Form != null)    
                {    
                    this.Form.Attributes.Add("autocomplete", "off");    
                }
        
                base.OnLoad(e);    
            }    
       }
