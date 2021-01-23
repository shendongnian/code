    public override void OnGUI(Rect pos, SerializedProperty prop, GUIContent label) {
        // Make a new serialized object for your property that is a class that inherits
        // from ScriptableObject
        SerializedObject serializedObject = new SerializedObject(prop.objectReferenceValue as MySOClass);
        SerializedProperty propSP = serializedObject.FindProperty("prop");
        if (propSP != null) {
            EditorGUI.BeginChangeCheck();
            EditorGUILayout.PropertyField(propSP , true);
            if (EditorGUI.EndChangeCheck()) {
                serializedObject.ApplyModifiedProperties();
            }
        }
    }
