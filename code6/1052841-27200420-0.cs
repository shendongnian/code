    String input = @"<html>
    ...
    <span id=""MyId"">string 1,string 2,string 3</span>
    ...
    </html>";
    Regex rgx = new Regex(@"(?:<span id=""MyId"">|\G),?([^<>,]+)");
    foreach (Match m in rgx.Matches(input))
    Console.WriteLine(m.Groups[1].Value);
