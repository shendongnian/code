    public struct Test {
      public readonly int A;
      public readonly string B;
    
      public Test(int a, string b) {
        A = a;
        B = b;
      }
    }
    
    var json = JsonConvert.SerializeObject(new Test(1, "Test"), new JsonSerializerSettings {
      ContractResolver = new CustomContractResolver()
    });
    var t = JsonConvert.DeserializeObject<Test>(json);
    t.A.ShouldEqual(1);
    t.B.ShouldEqual("Test");
