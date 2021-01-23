    public static MemberName([CallerMemberName] memberName = null)
    {
        return memberName;
    }
    public void Foo()
    {
        Log.Log(string.Format("I is inside of {0}", MemberName()));
    }
