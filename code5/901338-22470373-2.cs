    public void SomeMethod<A,B>()  where A : BaseTypeA where B : BaseTypeB
    {
      if(update)
      {
          var updateType = (A)request;
          updateType.Entity.NameFlag = nameValue;
          updateType.Entity.PhoneFlag = phoneValue;
      }
      else
      {
          var addType = (B) request;
          addType.Entity.NameFlag = nameValue;
          addType.Entity.PhoneFlag = phoneValue;
      }
    }
