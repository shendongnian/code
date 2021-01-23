        public Type GetType
        {
            get
            {
                var thisType = _baseObject.GetType();
                if (thisType.Namespace == "System.Data.Entity.DynamicProxies")
                    return thisType.BaseType;
                return thisType;
            }
        }
