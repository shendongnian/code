     void Update(){
        if(SceneUpdateRequired)
        {
            Application.LoadLevel(SceneUpdateID);
            SceneUpdateRequired = false;        
        }
        if (Application.isLoadingLevel == false)
        {              
            SceneUpdateRequired = false;
            SceneUpdateCompleted = true;
        }
     }
