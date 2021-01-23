    var input = @"/CallDump/CallInfo/KVP[@Key='Group' and (@Value='Best Group')]:10,
     /CallDump/CallInfo/child::KVP[@Key='Dept' and (@Value='Customer Service' or @Value='Sales')]:240,
     compare(Recordings/Recording/Location, 'New York')=0:20,
     default:5,";
    var expression = new Regex(@"(.+):(\d{1,3})");
    
    var result = input.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
                      .Select(x => x.Trim())
                      .Select(x => expression.Match(x))
                      .Select(m => new { Key = m.Groups[1].Value, Value = byte.Parse(m.Groups[2].Value) })
                      .ToDictionary(x => x.Key, x => x.Value);
