      public class A
      {
         protected bool seeMe;
      }
      public class B : A
      {
         public B()
         {
            base.seeMe = false; // this is A.seeMe
         }
         protected bool seeMe;
      }
      public class C : B
      {
         public C()
         {
            seeMe = true; // this is B.seeMe
         }
      }
