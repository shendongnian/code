    void OnGUI() {
        GUI.matrix = Matrix4x4.TRS(Vector2.zero, Quaternion.identity,new Vector3(Screen.width / 480.0f, Screen.height / 320.0f, 1)); 
        if (!btnTexture2) {
            Debug.LogError("Please assign a texture on the inspector");
            return;
        }
        //GUI.color = new Color(0,0,0,0);
          //GUI.backgroundColor = Color.clear;
    
        if (GUI.Button(new Rect(10, 10, 120, 30), btnTexture2))
           if (!IsOrbited) {
                MustOrbit = true;
            }
        }
        if(GUI.Button(new Rect(Screen.width*5/6,Screen.height*5/6,Screen.width/6,Screen.height/6),"reset")){
          transform.position = reset;
        }
