    using System.Text.RegularExpression;
    string text = readFromDocx();
    string newText = Regex.Replace( text, @"\.[^\S\n]*(\w)",
        m => string.Format( ". {0}", m.Groups[ 1 ] ) )
The double negation is meant to match all whitespaces except newlines, normally included in the \s specifier.
