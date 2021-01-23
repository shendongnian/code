    public bool HiddeMyLabel
    {
       set 
       { 
         if(value)
           lblRemainingPlacesMessage.Attributes.Add("style", "display:none");
         else
           lblRemainingPlacesMessage.Attributes.Add("style", "display:block");
       }
    }
