    var input = "Brown, Adam. (user)(admin)(Sales)";
    // var input = DDlistName.SelectedItem.ToString();
    var lastPick = input.Split(new[] { "(" }, StringSplitOptions.RemoveEmptyEntries).Last(); 
    var output = lastPick.Substring(0, lastPick.Length - 1);
    _UILabelPrintName.Text = output;
