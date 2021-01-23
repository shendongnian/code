    public class AmmoCounter : MonoBehaviour {
        public int ammo;
        public GameObject _pistol;     
        void Start( ){
            ammo = _pistol.GetComponent< Pistol >( );
        }
        void Update( ) {
            guiText.text = "Pistol: " + ammo + "/7";
        }
    }
