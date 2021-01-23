csharp
static string Indent(this string str, int count = 1, char indentChar = ' ')
{
    var indented = new StringBuilder();
    var i = 0;
    while (i < str.Length)
    {
        indented.Append(indentChar, count);
        var j = str.IndexOf('\n', i + 1);
        if (j > i)
        {
            indented.Append(str, i, j - i + 1);
            i = j + 1;
        }
        else
        {
            break;
        }
    }
    indented.Append(str, i, str.Length - i);
    return indented.ToString();
}
