            public static Delegate GetDelegate(object listItem)
            {
                return (Delegate)listItem.GetType()
                   .GetField("handler", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.GetField)
                   .GetValue(listItem);
            }
    
            public static object GetNext(object listItem)
            {
                return (Delegate)listItem.GetType()
                   .GetField("next", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.GetField)
                   .GetValue(listItem);
            }
