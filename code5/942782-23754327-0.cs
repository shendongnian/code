    class NotificationParameterComparer : IEqualityComparer<NotificationParameter>
    {
        public bool Equals(NotificationParameter x, NotificationParameter y)
        {
            if(x==null || y == null)
                return false;
            return x.Key == y.Key && x.Value == y.Value
        }
       
        public int GetHashCode(NotificationParameter parameter)
        {
            if (Object.ReferenceEquals(parameter, null)) return 0;
    
            int hashKey = parameter.Key == null ? 0 : parameter.Key.GetHashCode();
    
            int hashValue = parameter.Value.GetHashCode();
    
            return hashKey ^ hashValue;
        }
    }
