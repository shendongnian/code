         static private dynamic inst = null;
         public static dynamic Instance {
            get {
                return inst ?? new LocalizationHelper();
            }
         }
         
         public override bool TryGetMember(
            GetMemberBinder binder, out object result)
        {
            string name = binder.Name.ToLower();
    
            result = Resource.ResourceManager.GetString(name);
            return true;
        }
    }
