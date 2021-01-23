    public class ActionDemo
    {
         public void ActFunction(int a)
         {
         }
         public void ActFunction1()
         {
         }
     
         static void Main()
         {
            ActionDemo ad = new ActionDemo();
                 
     
            Action act1 = new Action(ad.ActFunction1);
            act1();     
            Action<int> act = new Action<int>(ad.ActFunction);
            act();
         }
    }
