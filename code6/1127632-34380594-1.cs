    using UnityEngine;
    using System.Collections;
    using UnityEditor;
    using UnityEngine.UI;
    using UnityEditor.UI;
    [CustomEditor (typeof(SubmitInputField), true)]
    [CanEditMultipleObjects]
    public class SubmitInputFieldEditor : InputFieldEditor
    {
	    SerializedProperty m_KeyboardDoneProperty;
	    SerializedProperty m_TextComponent;
	    protected override void OnEnable ()
	    {
		    base.OnEnable ();
		    m_KeyboardDoneProperty = serializedObject.FindProperty ("m_keyboardDone");
		    m_TextComponent = serializedObject.FindProperty ("m_TextComponent");
	    }
	    public override void OnInspectorGUI ()
	    {
		    base.OnInspectorGUI ();
		    EditorGUI.BeginDisabledGroup (m_TextComponent == null || m_TextComponent.objectReferenceValue == null);
		    EditorGUILayout.Space ();
		    serializedObject.Update ();
		    EditorGUILayout.PropertyField (m_KeyboardDoneProperty);
		    serializedObject.ApplyModifiedProperties ();
		    EditorGUI.EndDisabledGroup ();
		    serializedObject.ApplyModifiedProperties ();
	    }
    }
