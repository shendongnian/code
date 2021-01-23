    public Class Test
    {
         private bool _validatedOK = false;
         public void method1()
         {
             
             if(!_validatedOK) 
                  _validatedOK = MyValidation.isOk(s1);
             if{_validatedOK)
             {
                  ......
                  method2();
             }
         }
         public void method2()
         {
             
             if(!_validatedOK) 
                  _validatedOK = MyValidation.isOk(s1);
             if{_validatedOK)
             {
                  .....
             }
         }
    }
