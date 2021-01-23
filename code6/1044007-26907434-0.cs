    public class MyScript : MonoBehaviour
    {
       public bool flag;
       public int i = 1;
    }
 
    [CustomEditor(typeof(MyScript))]
    public class MyScriptEditor : Editor
    {
       void OnInspectorGUI()
       {
           var myScript = target as MyScript;
 
           myScript.flag = GUILayout.Toggle(myScript.flag, "Flag");
     
           if(myScript.flag)
               myScript.i = EditorGUILayout.IntSlider("I field:", myScript.i , 1 , 100);
 
       }  
    }
