         class Animal
         {
           protected void check()
           {}
           public void see()
           {}
         }
        class Mammal:Animal
        {
          public void CallSee()
            {
                Animal obja = new Animal();
                obja.see();
            }
        }
