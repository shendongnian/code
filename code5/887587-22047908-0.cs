    void OnGUI(){
        if(musicBool){
            GUI.DrawTexture(rect, musicOn);
        } else {
            GUI.DrawTexture(rect, musicOff);
        }
        if(GUI.Button(rect,"", new GUIStyle())){
            if (musicBool) {
                music.Pause();
                musicBool = false;
            }
            else {
                music.Play();
                musicBool = true;
            }
        } 
    }
