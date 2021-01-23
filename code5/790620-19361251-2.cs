      public class B : A
      {
         public B()
         {
            base.seeMe = false; // this is A.seeMe
         }
         [Obsolete("cannot use seeMe", error:true)]
         protected bool seeMe;
      }
      public class C : B
      {
         public C()
         {
            seeMe = true; // this will give a compile error
         }
      }
