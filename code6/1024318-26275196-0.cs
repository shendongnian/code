        static T[] MyConvert<T>(object value){
            T[] ret = null;
            if (value is Array)
            {
                Array arr = value as Array;
                ret = new T[arr.Length];
                for (int i = 0 ; i < arr.Length; i++ )
                {
                    ret[i] =  (T)Convert.ChangeType(arr.GetValue(i), typeof(T));.
                }
            }
            return ret;
        }
