    var postalAddress = new {
    	Line1 = "116 Knox St",
    	Line2 = "",
    	Line3 = "",
    	Line4 = "",
    	Suburb = "Watson",
    	StateCode = "ACT",
    	Pcode = "2602",
    };
    var builder = new StringBuilder();
    
    builder.AppendFormat("{0}, ", postalAddress.Line1);
    
    if(!string.IsNullOrEmpty(postalAddress.Line2))
    {
    	builder.AppendFormat("{0}, ", postalAddress.Line2);
    }
    if(!string.IsNullOrEmpty(postalAddress.Line3))
    {
    	builder.AppendFormat("{0}, ", postalAddress.Line3);
    }
    if(!string.IsNullOrEmpty(postalAddress.Line4))
    {
    	builder.AppendFormat("{0}, ", postalAddress.Line4);
    }
    
    builder.AppendFormat("{0}, ", postalAddress.Suburb);
    builder.AppendFormat("{0}, ", postalAddress.StateCode);
    builder.AppendFormat("{0}", postalAddress.Pcode);
    
    var result = builder.ToString();
