    #if UNITY_EDITOR
    using UnityEditor;
    #endif
    
    class Script: MonoBehaviour {
        void Update() {
    #if UNITY_EDITOR
            // Editor specific part here
    #endif
        }
    }
