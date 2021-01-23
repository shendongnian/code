    using UnityEngine;
    using System.Collections;
    using UnityEditor;
    
    [CustomEditor(typeof(MyScript))]
    public class MyScriptEditor : Editor {
    
    	public override void OnInspectorGUI()
    	{
    		var script = (MyScript) target;
    
    		script.someProperty = EditorGUILayout.IntField("A value", script.someProperty);
    		script.texture = (Texture) EditorGUILayout.ObjectField("Image", script.texture, typeof (Texture), false);
    	}
    }
