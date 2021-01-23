    Expression<Action> expr = () => myTestClass.myTestFunction();
    MethodCallExpression mbr = (MethodCallExpression)expr.Body;
    String methodName = mbr.Method.Name;
    Assert.AreEqual(methodName, "myTestFunction");
    MemberExpression me = (MemberExpression) mbr.Object;
    String memberName = me.Member.Name;
    Assert.AreEqual(methodName, "myTestClass");
    String finalName = string.Format("{0}.{1}()", memberName, methodName);
    Assert.AreEqual("myTestClass.myTestFunction()", finalName);
