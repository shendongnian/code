    public interface ISpecification<TObject>
    {
         // This holds the required field names
         IList<string> RequiredFields { get; }
         bool IsSatisfiedBy(TObject input);
    }
    
    
    public interface TextBoxSpecification : ISpecification<TextBox>
    {
        // This holds a relation between field names and their display name
        private readonly IDictionary<string, string> _fieldMapping = new Dictionary<string, string> 
        {
            { "tbVendorName", "Vendor name" },
            { "rtbVendorAddress", "Vendor address" },
            { "tbVendorEmail", "Vendor email" },
            { "tbVendorWebsite", "Vendor Web site" }
        };
    
          private readonly IList<string> _requiredFields = new List<string>();
    
          private IList<string> RequiredFields { get { return _brokenRules; } }
          private IDictionary<string, string> { get { return _fieldMapping; } }
    
          public bool IsSatisfiedBy(TextBox input)
          {
              bool valid = true;
              // If the condition isn't satisfied, the invalid field's diplay name is
              // added to RequiredFields
              if(!string.IsNullOrEmpty(input)) 
              {
                  valid = false;                  
                  RequiredFields.Add(FieldMapping[input.Name]);
              }
              
              return valid;
          }
    }
