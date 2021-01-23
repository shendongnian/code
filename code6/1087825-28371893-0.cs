    public class Test
    {
       public Test()
       {
    #IFDEF DEBUG
          SomeOnlyDebugeMehtod();
    #ENDIF
       }
    
    #IFDEF DEBUG
       private void SomeOnlyDebugeMehtod() {  }
    #ENDIF
    }
