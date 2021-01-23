    var pattern = @"^(?:[^\[]+).+(inflicted\s(?<Inflicted>[^\s]+))|(?<Evaded>evaded)|(yourself\s(?<Healed>[^\s]+))|(inflict\s(?<Critical>[^\s]+))|(take\s(?<Damage>[^\s]+))";
    
    var d2 = Regex.Matches(data, pattern, RegexOptions.Multiline)
                  .OfType<Match>()
                  .Select (mt => new
                  {
                      InflictedValue = mt.Groups["Inflicted"].Success ? double.Parse(mt.Groups["Inflicted"].Value) : 0,
                      HealedValue    = mt.Groups["Healed"].Success    ? double.Parse(mt.Groups["Healed"].Value) : 0,
                      Evades         = mt.Groups["Evaded"].Success    ? 1 : 0,
                      Critcal        = mt.Groups["Critical"].Success  ? double.Parse(mt.Groups["Critical"].Value) : 0,
                      Damage         = mt.Groups["Damage"].Success    ? double.Parse(mt.Groups["Damage"].Value) : 0,
                  })
                  ;
    
    d2.Dump(); // Linqpad way of showing data do not copy in production code.
    
    Console.WriteLine ("{0}Inflicted: {1}{0}Healed: {2}{0}Evaded: {3}{0}Criticals: {4}{0}Damage: {5}",
       Environment.NewLine,
       d2.Sum (itm => itm.InflictedValue),
       d2.Sum (itm => itm.HealedValue),
       d2.Sum (itm => itm.Evades),
       d2.Sum(itm => itm.Critcal),
       d2.Sum (itm => itm.Damage)
       );
