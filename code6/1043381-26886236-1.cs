    var lines = File.ReadLines(dir).Skip(1);
    if (!lines.Any())
    {
        MessageBox.Show("", "");
        return;
    } 
    foreach (var line in lines)
    {
        //process line here
    }
