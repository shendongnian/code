    foreach(string ss in prop1)
    {
        if(GUI.Button(new Rect(0, 100+w, 100, 100), prop1[count].ToString()))
        {
            SelectType(ss);
        }
    
    }
    public void SelectType(string type)
    {
    
        if (obj["building"].Value == type) 
        { 
            GameObject sceneObject = GameObject.Find("#" + key);
            sceneObject.renderer.material.color = Color.blue;
        }
    }
