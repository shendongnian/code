       abstract class Animal
       {
           public string DefaultMessage { get; set; }
    
           public Animal()
           {
               Console.WriteLine("Animal Cstor called");
               DefaultMessage = "Default Speak";
           }
           public virtual void Speak()
           {
               Console.WriteLine(DefaultMessage);
           }
       }
    
        class Dog : Animal
        {
            public Dog(): base()//base() redundant.  There's an implicit call to base here.
            {
                Console.WriteLine("Dog cstror called");
            }
            public override void Speak()
            {
                Console.WriteLine("Custom Speak");//append new behavior
                base.Speak();//Re-use base behavior too
            }
        }
