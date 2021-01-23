     public class scriptFlashingPressStart : MonoBehaviour  
        {   
            public GameObject off_Logo;
            public float dead_logo = 1.5f;
            bool pressed = false;
    
        void OffLogo()  
        {       
           //do anything(delete or invisible)
            off_Logo.SetActive(false);
             pressed = false;  
        }
    
       //use Invoke rather than InvokeRepeating
        void press_start()
        {
            if(!pressed)
            {
              pressed = true;
              Invoke("OffLogo", dead_logo);
            }
            else
            {
              Debug.Log("Button already pressed");
            }
        }
    }
