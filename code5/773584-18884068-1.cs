    public class Converter
    {
       public Converter(ISourceReader reader, IValidator validator, IFilter filter,IOutputformatter formatter)
       {
          //boring saving of dependencies to local privates here...
       }
    
       public bool Convert(string data,string filter)
       {
           if (!validator.Validate(data)) return false;
           var filtered = filter.Filter(data); 
           var raw = reader.Tokenise(filtered);
           var result = formatter.Format(raw);
           //and so on
           return true; //or whatever...
       }    
    }
