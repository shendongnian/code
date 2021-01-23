    public class tilechange : MonoBehaviour {
        public Material Black;
        public Material Grey;
        public Material OGrey;
        void Start()
        {
            renderer.material = Grey;
        }
        void OnMouseDown()
        {
            Debug.Log("click worked");
            if (PlayerPrefs.GetInt("Colour") == 1)
            {
                renderer.material = Grey;
                Debug.Log("grey");
            }
            if (PlayerPrefs.GetInt("Colour") == 2)
            {
                renderer.material = Black;
                Debug.Log("black");
            }
            if (PlayerPrefs.GetInt("Colour") == 3)
            {
                renderer.material = OGrey;
                Debug.Log("OGrey");
            }
        }
    }
