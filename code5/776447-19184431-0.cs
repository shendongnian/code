    [SolutionComponent]
    public class BulbItemInstrumentationComponent : IBulbActionprovider
    {
      public int Priority { get{ return int.MaxValue; } }
      
      public object PreExecute(ITextControl tc) { return null; }
      
      public void CollectActions(IntentionsBulbItems ibis, ...)
      {
        var bulbItems = ibis.AllBulbMenuItems;
        foreach (var execItem in bulbItems.Select(item => item.ExecutableItem))
        {
          var proxy = execItem as IntentionAction.MyExecutableProxi;
          if (proxy != null)
          {
            proxy.WrapBulbAction();
            continue;
          }
          
          var exec = execItem as ExecutableItem;
          if (exec != null)
          {
            exec.WrapBulbAction();
            continue;
          }
          
          throw new Exception("unexpected item type: " + execItem.GetType().FullName);
        }
      }
    }
