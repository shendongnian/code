        static void CloseIfClosable(object o)
        {
            Type oType = o.GetType();
            MethodInfo closeMethod = oType.GetMethod("Close");
            if (closeMethod != null)
            {
                closeMethod.Invoke(o, new object[] { });
            }
        }
