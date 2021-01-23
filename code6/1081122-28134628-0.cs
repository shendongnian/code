    var s = new StringBuilder();
    foreach (var textbox in this.Controls.OfType<TextBox>())
    {
       s.AppendLine(textbox.Text)
    }
    Console.WriteLine(s.ToString());
