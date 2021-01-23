     public interface DragableObject
     {
         void DragMe();
     }
     public class Star : MonoBehaviour, DragableObject
     {
         public void DragMe()
         {
             print("I am a Star, I don't move easily.");
         }
     }
     public class Ship : MonoBehaviour, DragableObject
     {
         public void DragMe()
         {
             print("Engaging warp speed.");
         }
     }
