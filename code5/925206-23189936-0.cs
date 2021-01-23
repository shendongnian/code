    //notice these are pulled out from the method and now attached to the script
    string email = ""; 
    string username = "";
    string password = "";
    string confirm = "";
    
    void OnGUI () {
    
        email = GUI.TextField (new Rect (250, 93, 250, 25), email, 40);
        username = GUI.TextField ( new Rect (250, 125, 250, 25), username, 40);
        password = GUI.PasswordField (new Rect (250, 157, 250, 25), password, "*"[0], 40);
        confirm = GUI.PasswordField (new Rect (300, 189, 200, 25), confirm, "*"[0], 40);
    
        if (GUI.Button (new Rect (300, 250, 100, 30), "Sign-up")) {
            Debug.Log(email + " " + username + " " + password + " " + confirm);
        }
    }
