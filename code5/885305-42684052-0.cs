        public static bool ExecuteSet(string key, object value) {
            return ExecuteSet(key, value, ExpirationTimeEnum.Never);
        }
        
        public static bool ExecuteSet(string key, object value, ExpirationTimeEnum expirationTime) { /* ... */ }
