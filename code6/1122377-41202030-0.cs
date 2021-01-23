    public static class InvocationHelper
    {
        public static Dictionary<string,Delegate[]> GetInvocationList<TClass>(TClass source)
        {
            if (null == source)
                return new Dictionary<string, Delegate[]>();
            var retval = new Dictionary<string,Delegate[]>();
            var members = typeof (TClass).GetMembers(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic).
                Where(t=>t.MemberType == MemberTypes.Event).ToArray();
            foreach (var memberInfo in members)
            {
                var field = typeof (TClass).GetField(memberInfo.Name,
                    BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                
                if (field == null) 
                    continue;
                var delegateField = field.GetValue(source) as Delegate;
                if(null == delegateField)
                    continue;
                retval[memberInfo.Name] = delegateField.GetInvocationList();                
            }
            return retval;
        }
    }
