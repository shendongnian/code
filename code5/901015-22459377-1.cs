    var info = personContainer.GetType();
    if (info.IsGenericType)
    {
         var attributes = (MsgAttribute[])info.GetGenericArguments()[0]
                          .GetCustomAttributes(typeof(MsgAttribute), false);
    }
