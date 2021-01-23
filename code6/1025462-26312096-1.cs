    public class PlayStop : MonoBehaviour {
    
        public AudioClip aclip;
        public AudioSource audios;
        private bool stop;
        
         void Start()
            {
               audios.clip=aclip;
               stop=true;
            }
        
        void Update () {
                if (Input.GetMouseButtonDown (0)) {
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    RaycastHit hit;
                    if (Physics.Raycast(ray, out hit)) {
                        if(hit.collider.tag=="stop" && !stop)
                              {
                                      audios.Stop();
                                      stop=!stop
                              }
                     if(hit.collider.tag=="play" && stop)
                              {
                                      audios.Play();
                                      stop=!stop
                              }
                    
                    }
                }
            }
    }
