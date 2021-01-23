    public bool IsTypeA 
    { 
         get { return ThreeStateType == MyType.A; } 
         set { if (value) ThreeStateType = MyType.A; }
             //   in this case it is not clear what to do 
             //   if the external routine sets IsTypeA  to [false]
    }
