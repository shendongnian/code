    using UnityEngine;
    using UnityEditor;
    using UnityEngine.UI;
    using System.Collections;
    [CustomEditor(typeof(UISegmentedControlButton))]
    public class UISegmentedControlButtonEditor : UnityEditor.UI.ButtonEditor {
	public override void OnInspectorGUI() {
		UISegmentedControlButton component = (UISegmentedControlButton)target;
		base.OnInspectorGUI();
		component.onSprite = (Sprite)EditorGUILayout.ObjectField("On Sprite", component.onSprite, typeof(Sprite), true);
		component.onTextColor = EditorGUILayout.ColorField("On text colour", component.onTextColor);
		component.offSprite = (Sprite)EditorGUILayout.ObjectField("Off Sprite", component.offSprite, typeof(Sprite), true);
		component.offTextColor = EditorGUILayout.ColorField("Off text colour", component.offTextColor);
	}
    }
