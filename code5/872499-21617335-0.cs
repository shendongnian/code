    public void SomeMethod(string myFirstParam = "", string mySecondParam = "", MyEnum? myThirdParam = null)
    {
       if (myThirdParam.HasValue)
       {
          var enumValue = myThirdParam.Value;
          //do something with it
       }
    }
