    var simple = new Simple3Des("randompass");
    var input = txtAccount.Text.Split(new[] {Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries);
    var output = new StringBuilder();
    foreach (var i in input)
        output.AppendLine(simple.Encode(i));
    txtEncrypted.Text = output.ToString();
