    public class handleInput: MonoBehaviour {
             
        void Update () {
            if (Input.GetMouseButtonDown (0)) {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit)) {
                    if (hit.collider.tag=="jumpbutton"){
                        jump();
                    }      
                }
            }
        }
    }
