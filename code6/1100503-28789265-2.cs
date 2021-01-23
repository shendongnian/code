        public void AddAction(Action<int,bool> a, object cls, string eventName)
        {
            var eventVar = cls.GetType().GetEvent(eventName);
              a += delegate(int x, bool condition)
            {
                MyEvent(x, condition);
            };
           
              eventVar.AddEventHandler(cls, a);
        }
