     public bool Validate() 
            {
                var isValid = false;
    Page.Validate("vgLinR");
                isValid = Page.IsValid;
                if (isValid) 
                {
                Page.Validate("vgLogR");
                    isValid = Page.IsValid;
                }
        
                return isValid;
            }
