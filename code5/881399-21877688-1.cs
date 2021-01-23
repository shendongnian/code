    public class Test
    {
      public int testField = 23;
    }
    
    public static class Tester
    {
      public static int GetTestField(Test test)
      {
        return test.testField;
      }
    }
