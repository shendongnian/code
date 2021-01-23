        //This is the Awake () function, part of the Monobehaviour class
        //You can put this in Start () also
        void Awake () {
            UnityEngine.GameObject guiMenu = GameObject.FindWithTag ("Canvas");
        }
        // Same as your code
        void Update () {
            if ((Input.GetKey ("p")) && (stoppedMovement == true)) {
                stoppedMovement = false;
                walkScript.enabled = true;
                guiMenu.SetActive(true);
            } else if ((Input.GetKey ("p")) && (stoppedMovement == false)) {
                stoppedMovement = true;
                walkScript.enabled = false;
                guiMenu.SetActive(false);
            }
        }
