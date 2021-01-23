        public class ScriptManager : MonoBehaviour 
        {
    	   public Object [] list;
    	
    	   void Awake()
    	   {
    		   // Comment this line if you used step 1 above.
               list = Resources.LoadAll("Scripts"); 
    
    		   gameObject.AddComponent(list[0].name);
    	   }
        }
