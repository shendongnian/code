    public static void ChangeCommonProperties(dynamic thirdPartyObject){
      thirdPartyObject.A = "Hello";
      thirdPartyObject.B = "World";
    }
    ChangeCommonProperties(new Foo());
    ChangeCommonProperties(new Bar());
