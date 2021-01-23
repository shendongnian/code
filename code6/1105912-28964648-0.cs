    var inputStr = @"// YOUR INPUT STRING "
    var rxDelim = new Regex(@"(?(:):\s*|\s{3,})\s*");
    var matches = inputStr.Split(new[] { "\n", "\r" }, StringSplitOptions.RemoveEmptyEntries).Select(p => rxDelim.Split(p).GetLength(0) > 1 && rxDelim.Split(p)[0] != "*" && !rxDelim.Split(p)[0].TrimStart(new[] {' '}).StartsWith("//") ? 
                       new { Key = rxDelim.Split(p)[0], Value = rxDelim.Split(p)[1] } :
                       new { Key = string.Empty, Value = string.Empty });
    var output = string.Empty;
    foreach (var v in matches)
       if (!String.IsNullOrWhiteSpace(v.Key) && !String.IsNullOrWhiteSpace(v.Value))
          output += string.Format("{0}\t{1}", v.Key, v.Value) + "\r\n";
    MessageBox.Show(output);
