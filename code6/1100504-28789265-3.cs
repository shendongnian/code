    public class Test<I, B> {
        ....
         public event Action<I, B> MyEvent2;
          public void AddAction2(Action<I, B> a, object cls, string eventName)
          {
              var eventVar = cls.GetType().GetEvent(eventName);
              a += delegate(I x, B condition)
              {
                  MyEvent2(x, condition);
              };
              eventVar.AddEventHandler(cls, a);
          }
