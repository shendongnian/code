    static public void main(string[] args)
    {
        //create Boo2, a dynamic method with Boo signature.
        var boo2 = new DynamicMethod("Boo2", typeof(void), new Type[] { typeof(Foo) }, typeof(Foo), true);
        var body = boo2.GetILGenerator();
        //Fill your ILGenerator...
        body.Emit(OpCodes.Ret);
        //Apply the patch
        MonkeyPatch.Patch(typeof(Foo).GetMethod("Boo"), boo2);
    }
