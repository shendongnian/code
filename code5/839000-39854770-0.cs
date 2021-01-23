    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    // ...
    var s = "Hi {there} I {1} a string.";
    var result = Regex.Matches(s, @"{[^{}\d]*}")
    	.Cast<Match>()
    	.Select(p => p.Value)
    	.ToList();
