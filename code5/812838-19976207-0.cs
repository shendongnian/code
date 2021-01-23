    public class MyClass{
        static MyStaticConstructor() {
            SceneView.onSceneGUIDelegate += OnScene;
        }
        static void OnScene(SceneView sceneView) {
            // Draw GUI stuff here for Scene window display
        }
    }
