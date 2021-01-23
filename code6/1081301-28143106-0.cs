    public class ChooseMort : MonoBehaviour
    {
        public Boss mort;
        private GameSettings gameSettings;
        // Use this for initialization
        void Start ()
        {
            gameSettings = new GameSettings();
        }
    
        // Update is called once per frame
        void Update ()
        {
        }
    
        void OnMouseOver(){
            if(Input.GetMouseButtonDown(0)){
                gameSettings.chosenBoss = mort;
                Application.LoadLevel("MainGame");
            }
        }
    }
