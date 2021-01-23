    void OnGUI() {
        if (GUI.Button(new Rect(10, 70, 50, 30), "Open webpage!")){
            Application.OpenURL("http://gameone.co/");
        }
    }
