    using UnityEngine;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEditor;
    // uncomment this line bellow if you want to create customEditor script which you will be able to use on gameObject as component.
    // typeof give script type , it's a script created as component and extending from Monobehaviour, he contain value etc.. he could be manipulated from this CustomEditor script via button who call Methodes.
    //[CustomEditor(typeof(YourScriptComponent))]
    public class MyNewCustomEditor : Editor
    {}
