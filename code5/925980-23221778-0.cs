            object obj = Activator.CreateInstance(type);
            BindingFlags myBindingFlags = BindingFlags.Instance | BindingFlags.Public;
            // Find the event and its type
            EventInfo ei = obj.GetType().GetEvent("OnErrorHandler", myBindingFlags);
            var delegateType = ei.EventHandlerType;
            // Use our own event handler
            var mycallback = typeof(Program).GetMethod("Callback", BindingFlags.Static | BindingFlags.NonPublic);
            Delegate del = Delegate.CreateDelegate(delegateType, null, mycallback);
            ei.AddEventHandler(obj, del);
            // Call the Run method
            MethodInfo methodInfo = obj.GetType().GetMethod("Run");
            bool Result = (bool)methodInfo.Invoke(obj, null);
            
