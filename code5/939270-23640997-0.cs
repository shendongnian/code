        public class Singleton {
          private static Singleton theInstance;
          private Singleton(){
            theInstance=null;
          }
          public static Singleton getInstance(){
           if ( theInstance==null )
             theInstance= new Singleton();
             return theInstance;
           }
        }
