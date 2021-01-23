    public class MyOtherScript
    {
        public FleeScript prefabWithFleeScript; // Linked from the Editor
        void Awake()
        {
            FleeScript fleeScript= Instantiate(prefabWithFleeScript);
            // do something with fleeScript
        }
    }
