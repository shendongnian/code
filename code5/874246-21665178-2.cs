    static class Test { 
      static readonly bool example;
    
      static Test() { 
        example = true;
      }
    
      internal static void Go() { 
        // example == true 
      }
    }
    
    class Program { 
    
      static void Main() {
        // Test.example == false;
        Test.Go();  
      }
    }
