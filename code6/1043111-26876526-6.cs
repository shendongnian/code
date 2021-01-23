    string pattern = @"^       # Beginning of line to anchor it.
    (?=.+\[System\])           # Within the line a literal '[System]' has to occur
    (?=.+                      # Somewhere within that line search for these keywords:
      (?<Action>               # Named Match Capture Group 'Action' will hold a keyword.
              inflicte?d?      # if the line has inflict or inflicted put it into 'Action'
              |                # or
              evaded           # evaded
              | take           # or take
              | yourself       # or yourself (heal)
       )
      (\s(?<Value>[\d.]+))?)   # if a value of points exist place into 'Value'
    .+                         # match one or more to complete it.
    $                          #end of line to stop on";
    
     // IgnorePatternWhiteSpace only allows us to comment the pattern. Does not affect processing.
    var tokens =
       Regex.Matches(data, pattern, RegexOptions.IgnorePatternWhitespace | RegexOptions.Multiline)
            .OfType<Match>()
            .Select( mt => new {
                                Action = mt.Groups["Action"].Value,
                                Value  = mt.Groups["Value"].Success ? double.Parse(mt.Groups["Value"].Value) : 0,
                                Count  = 1,
                               })
             .GroupBy ( itm => itm.Action,  // Each action will be grouped into its name for summing
                        itm => itm,   // This is value to summed amongst the individual items of the group.
                		(action, values) => new
                                {
                             	    Action = action,
                                    Count  = values.Sum (itm => itm.Count),
                                    Total  = values.Sum(itm => itm.Value)
                                 }
                             );
