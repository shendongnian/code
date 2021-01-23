          public class PlayStop : MonoBehaviour {
            
                public AudioClip aclip;
                private bool stop;
                
                 void Start()
                    {
                       audio.clip=aclip;
                       stop=true;
                    }
                
              
        void Update () 
         {
            if(Input.touches.Length == 1)
            {
            Touch touchedFinger = Input.touches[0];
         
            if(touchedFinger.phase==TouchPhase.Began){ 
             Ray aRay = Camera.mainCamera.ScreenPointToRay(touchedFinger.position);
              RaycastHit hit;
              if(Physics.Raycast(aRay.origin, aRay.direction, out hit, Mathf.Infinity))
                   {
                          
                                if(hit.collider.tag=="stop" && !stop)
                                      {
                                              audio.Stop();
                                              stop=!stop
                                      }
                             if(hit.collider.tag=="play" && stop)
                                      {
                                              audio.Play();
                                              stop=!stop
                                      }
                            
                            }
                        }
                    }
            }
    }
