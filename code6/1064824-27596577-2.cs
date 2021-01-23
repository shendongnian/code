    public class MyWrapper
    {
       private GameObject parentGameObj;
       public MyWrapper(GameObject srcObj)
       {
          parentGameObj = srcObj;
       }
    
       public GameObject GameObjectCache 
       { 
           get 
           { 
               if (gameObjectCache == null)
                   gameObjectCache = parentGameObj.gameObject;
               return gameObjectCache; 
           } 
       }
       private GameObject gameObjectCache;
    
       public Transform TransformCache 
       { 
           get 
           { 
               if (transformCache == null)
                   transformCache = parentGameObj.GetComponent<Transform>();
               return transformCache; 
           } 
       }
       private Transform transformCache;
    }
