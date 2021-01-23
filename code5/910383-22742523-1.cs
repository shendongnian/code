       public class A : IA
       {
       }
    
       public interface IA<out T>
       {
       }
    
       public class B where T : IA
       {
       }
