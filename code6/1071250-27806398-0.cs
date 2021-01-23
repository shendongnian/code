    using UnityEngine;
    using System.Collections;
    using UnityEditor;
    using System.IO;
    
    [ExecuteInEditMode]
    public class CharacterTools : MonoBehaviour
    {
        [SerializeField, HideInInspector]
        private string className;
    
        private bool waitForCompile = false;
    
        private void Update()
        {
            if (string.IsNullOrEmpty(className))
                return;
    
            if (waitForCompile && EditorApplication.isCompiling)
                waitForCompile = false;
    
            if (!waitForCompile && !EditorApplication.isCompiling)
            {
                var gameObject = new GameObject(className);
                Debug.Log("Attempting to add " + className);
                var c = gameObject.AddComponent(className);
    
                className = null;
            }
        }
    
        [ContextMenu("Create character")]
        private void CreateCharacter()
        {
            string name = "Number" + Random.Range(0, 100).ToString();
    
            string nameTemplate = "{0}Character";
            string contentTemplate = @"using UnityEngine;
    
    public class {0} : MonoBehaviour
    {{
    }}
    ";
    
            var className = string.Format(nameTemplate, name);
            var path = Application.dataPath + "/" + className + ".cs";
    
            var scriptFile = new StreamWriter(path);
            scriptFile.Write(string.Format(contentTemplate, className));
            scriptFile.Close();
    
            AssetDatabase.ImportAsset(path, ImportAssetOptions.ForceSynchronousImport);
            AssetDatabase.Refresh();
    
            this.className = className;
            this.waitForCompile = true;
        }
    }
