    GetData<float>("2.2")
    GetData<string>("2.2")
 
    public static T GetData<T>(string a)
            {
                return (T)Convert.ChangeType(a, typeof(T));
            }
 
