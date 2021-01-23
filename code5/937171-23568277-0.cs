    var eventArgs = EventArgs.Empty; //replace with real args
    var eventInfo = tExForm.GetType().GetEvent("Click", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
    var eventDelegate = (MulticastDelegate)tExForm.GetType().GetField("Click", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(tExForm);
    if (eventDelegate != null)
    {
      foreach (var handler in eventDelegate.GetInvocationList())
      {
        handler.Method.Invoke(handler.Target, new object[] { tExForm, eventArgs });
      }
    }
