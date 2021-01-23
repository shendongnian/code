    static class BulbItemInstrumentationExtensions
    {
      private static readonly MethodInfo MyExecutableProxiBulbActionSetter =
        typeof (IntentionAction.MyExecutableProxi).GetProperty("BulbAction").GetSetMethod(true);
      private static readonly FieldInfo ExecutableItemActionField =
        typeof (ExecutableItem).GetField("myAction", BindingFlags.NonPublic | BindingFlags.Instance);
      
      public static void WrapBulbAction(this IntentionAction.MyExecutableProxi proxi)
      {
        var originalBulbAction = proxy.BulbAction;
        var bulbActionProxy = new LoggingBulbActionProxy(originalBulbAction);
        MyExecutableProxiBulbActionSetter.Invoke(proxy, new object[] {bulbActionProxy});
      }
      public static void WrapBulbAction(this ExecutableItem exec)
      {
        var originalAction = (Action) ExecutableItemActionField.GetValue(exec);
        var actionProxy = new LoggingActionProxy(originalAction);
        var newAction = (Action) (wrapper.Execute);
        ExecutableItemActionField.SetValue(exec, newAction);
      }
    }
