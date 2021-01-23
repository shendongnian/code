    public class TagGarbageTest : MonoBehaviour
    {
        public int iterations = 1000;
        string s;
        void Start()
        {
            for (int i = 0; i < iterations; i++)
                s = gameObject.tag;
        }
    }
