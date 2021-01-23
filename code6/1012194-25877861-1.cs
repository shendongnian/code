    using UnityEngine;
    using System.Collections;
    
    public class ExampleClass : MonoBehaviour {
        void Start() {
            GameObject go = GameObject.CreatePrimitive(PrimitiveType.Cube);
            go.renderer.material.mainTexture = Resources.Load("glass", typeof(Texture2D));
        }
    }
