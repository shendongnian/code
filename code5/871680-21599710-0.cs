     public class scriptFlashingPressStart : MonoBehaviour  
        {   
            public GameObject off_Logo;
            public float dead_logo = 1.5f;
    
        void OffLogo()  
        {       
           //do anything(delete or invisible)
            off_Logo.SetActive(false);  
        }
    
       //use Invoke rather than InvokeRepeating
        void press_start()
        {
            Invoke("OffLogo", dead_logo);
        }
    }
