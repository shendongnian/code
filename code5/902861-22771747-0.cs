    public class MyModel : IDataErrorInfo
    {
        /// <summary>
        /// Stores error descriptions for the properties.
        /// </summary>
        Hashtable propertyErrors;
        /// <summary>
        /// Stores an error description for the item.
        /// </summary>
        String fNoteError;
       /// <summary>
       /// Gets and sets an error for the current item
       /// </summary>
       internal string NoteError
       {
           get { return fNoteError; }
           set
           {
               if (fNoteError != null && fNoteError == value) return;
               fNoteError = value;
           }
        }
       
        //Returns an error description set for the item's property
        string IDataErrorInfo.this[string columnName]
        {
            get
            {
               return GetColumnError(columnName);
            }
        }
        //Returns an error description set for the current item
        string IDataErrorInfo.Error
        {
            get { return NoteError; }
        }   
        public String NameOfColumnA { get; set; }
        public String NameOfColumnB { get; set; }
        public MyModel()
        {
           propertyErrors = new Hashtable { { "NameOfColumnA", "" }, { "NameOfColumnB", "" }};
           fNoteError = "";
        }     
        //Sets an error for an item's property
        public void SetColumnError(string elem, string error)
        {
            if (propertyErrors.ContainsKey(elem))
            {
                if ((string)propertyErrors[elem] == error) return;
                propertyErrors[elem] = error;
            }
        }
        //Gets an error for an item's property
        public string GetColumnError(string elem)
        {
           if (propertyErrors.ContainsKey(elem))
              return (string)propertyErrors[elem];
           else
              return "";
        }
      
        public void ClearErrors()
        {
           SetColumnError("NameOfColumnA", "");
           SetColumnError("NameOfColumnB", "");           
           NoteError = "";
        }
    }
