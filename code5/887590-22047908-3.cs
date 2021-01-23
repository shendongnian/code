    public GUIStyle musicOff; //assign a GUIStyle with the correct button image for off
    private GUIStyle musicOn; //assign a GUIStyle with the correct button image for on
    private GUIStyle musicGUIStyle; //holds GUIStyle being displayed. Assign this a default
    void OnGUI(){
        if(GUI.Button(rect,"", musicGUIStyle)){
            if (musicBool) {
                music.Pause();
                musicBool = false;
                musicGUIStyle = musicOff;
            }
            else {
                music.Play();
                musicBool = true;
                musicGUIStyle = musicOn;
            }
        } 
    }
