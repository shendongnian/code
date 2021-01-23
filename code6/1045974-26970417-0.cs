        public class DynamicBrand : DynamicObject
        {
            private IDictionary<string, object> myDynamicValues;
        
            public DynamicBrand()
                    : base()
            {
                myDynamicValues = new Dictionary<string, object>();
            }
        
            public void AddMember(string Name, object Value)
            {
                if (!myDynamicValues.ContainsKey(Name.Trim().ToLower()))
                {
                    myDynamicValues.Add(Name.ToLower().Trim(), Value);
                }
                else
                {
                    throw new Exception("The Member with the Name: " + Name + " already exists!");
                }
            }
            public override bool TrySetMember(SetMemberBinder Binder, object Value)
            {
                if (myDynamicValues.ContainsKey(Binder.Name.ToLower()))
                {
                    myDynamicValues[Binder.Name.ToLower()] = Value;
                    return true;
                }
                else
                {
                    myDynamicValues.Add(Binder.Name.ToLower(), Value);
                }
        
                return true;
            }
            
            publc override bool TryGetMember(GetMemberBinder Binder, out object Result)
            {
                if (myDynamicValues.ContainsKey(Binder.Name.ToLower()))
                {
                    Result = myDynamicValues[Binder.Name.ToLower()];
                    return true;
                }
                else
                {            
                    Result = null;
                    return false;
                 }
            }
