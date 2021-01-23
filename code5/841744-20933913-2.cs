     readonly Dictionary<Tuple<Type, MethodInfo>, Attribute> attributeCache = new Dictionary<Tuple<Type, MethodInfo>, Attribute>();
              
     T GetSingleAttributeOrDefault<T>(PropertyInfo propertyInfo) where T : Attribute, new()
        {            
            Type attributeType = typeof(T);
            Attribute attribute;
           
            //var key = new PointerPair(propertyInfo.GetGetMethod().MethodHandle.Value, attributeType.TypeHandle.Value);
            var key = new Tuple<Type, MethodInfo>(attributeType, propertyInfo.GetGetMethod());
            if (!attributeCache.TryGetValue(key, out attribute))
                attributeCache.Add(key, attribute = base.GetSingleAttributeOrDefault<T>(propertyInfo));
            return attribute as T;
        }
