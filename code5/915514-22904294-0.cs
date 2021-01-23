    public static class FooOrBar
    {
	public static string What { get { return  " <#= MyHelpers.GetString(true) #> "; } }
    }
    <#+
    public static class MyHelpers {
        public static string GetString(bool what)
        {
            return what ? "foo" : "bar";
        }
    }
    #>
