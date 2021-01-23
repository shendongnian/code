    public class AmmoCounter : MonoBehaviour {
    
        public int ammo;
        private Pistol _pistol = GetComponentInChildren<Pistol>();     
    
        void Update () {
            ammo = _pistol.ammoMagazine;
            guiText.text = "Pistol: " + ammo + "/7";
        }
    }
