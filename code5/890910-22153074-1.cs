    using System.Text.RegularExpressions;
    ...
    Regex regX = new Regex(
    	@"(\d{1,2}):(\d{1,2})-([a-z]{2})-(\d{3,5})",
    	RegexOptions.IgnoreCase
    );
    
    if( regX.IsMatch( inputString ) )
    {
        // Matched
    }
    
    ...
