    private Texture musicTexture;    
    void OnGUI(){
        GUI.DrawTexture(rect, musicTexture);
        if(GUI.Button(rect,"", new GUIStyle())){
            if (musicBool) {
                music.Pause();
                musicBool = false;
                musicTexture = musicOff
            }
            else {
                music.Play();
                musicBool = true;
                musicTexture = musicOn
            }
        } 
    }
