    public Class ValidatedText 
    {
        private string vText;
        private bool valid = true;
        Int23 maxLen = 0;
        public bool Valid 
        {   
           get { return valid; }
           set 
           {  
              if (valid == value) return;
              valid = value;
           }
        } 
        public string Vtext 
        {  
           get { return vText; }
           set 
           {  
              if (vText == value) return;
              if (value.Len < 0) 
              {
                  Valid = false;
                  return;
              }
              // do additional validation here
              vText = value;
           } 
       }
       public ValidatedText (string VText; Int32 MaxLen)
       {   vText = Vtext; maxLen - MaxLen;   }
    }
