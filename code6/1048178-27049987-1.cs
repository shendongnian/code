    void OnGUI() {
        EditorGUILayout.BeginHorizontal();
        {
            scroll = EditorGUILayout.BeginScrollView(scroll, GUILayout.Width(200), GUILayout.Height(500));
            {
                GameObject[] gameObjects = GameObject.FindObjectsOfType(typeof(GameObject)) as GameObject[];
                foreach (GameObject go in gameObjects) {
                    // Start with game objects without any parents
                    if (go.transform.parent == null) {
                        // Show the object and its children
                        ShowObject(go, gameObjects);
                    }
                }
            }
            EditorGUILayout.EndScrollView();
        }
        EditorGUILayout.EndHorizontal();
    }
    void ShowObject(GameObject parent, GameObject[] gameObjects) {
        // Show entry for parent object
        if (UnityEditor.EditorGUILayout.Foldout(IsEntryOpen(parent), parent.name)) {
            foreach (GameObject go in gameObjects) {
                // Find children of the parent game object
                if (go.transform.parent == parent.transform) {
                    ShowObject(go, gameObjects);
                }
            }
        }
    }
