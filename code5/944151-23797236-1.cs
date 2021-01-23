    [InitializeOnLoadAttribute]
    public class YourWindow : EditorWindow
    {
        const string path = @"Assets/Bla-bla-bla.cs";
        private static bool justRecompiled;
        static YourWindow()
        {
            justRecompiled = true;
        }
        [MenuItem("Test/YourWindow")]
        public static void Generate()
        {
            GetWindow(typeof(YourWindow));
        }
        private bool waitingForRecompiling;
        private GameObject gameObject;
        public void OnRecompile()
        {
            MonoScript monoScript = AssetDatabase.LoadAssetAtPath(path, typeof(MonoScript)) as MonoScript;
            Type monoScriptClass = monoScript.GetClass();
            if (gameObject.GetComponent(monoScriptClass) == null)
                gameObject.AddComponent(monoScriptClass);
        }
        public void OnGUI()
        {
            if (GUILayout.Button("Execute"))
                if (Selection.activeGameObject != null)
                {
                    // Do your script file generation here
                    waitingForRecompiling = true;
                    gameObject = Selection.activeGameObject;
                    AssetDatabase.ImportAsset(path);
                }
        }
        public void Update()
        {
            if (justRecompiled && waitingForRecompiling)
            {
                waitingForRecompiling = false;
                OnRecompile();
            }
            justRecompiled = false;
        }
    }
