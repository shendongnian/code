    public string FormatArrayValues(string[] arrayValues){
                
                //remove null values
                arrayValues = arrayValues.Where(w=>w != null);
                
                //begin loop
                for(int j = 0;j < arrayValues.Count();j++){
                
                //call the current method recursively (may need to check if the type is an array or simple type here)!
                s += String.Format("{{{0}:{1}}}",j,this.FormatArrayValues(copiedarray.GetValue(j)));
                }
                
            return s
    }
