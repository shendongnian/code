    public static IEnumerable<T> GetItemsAsT<T>(this GameObject[] objects) 
        where T:Component
        {
            foreach(var obj in objects)
            {
                var t = obj.GetComponent<T>();
                if(t != null)
                    yield return t;
            }
            yield break;
        }
    
