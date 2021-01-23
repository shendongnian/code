    public static string Truncate(string source, int length)
    {
    if (source.Length > length)
    {
        source = String.Concat(source.Substring(0, length), " ...");
    }
    return source;
    }
    <span id="userNameText">
    	<%= Truncate(string.Concat(Eval("FirstName"), " ", Eval("LastName")).ToString(), 21) %>
    </span>
