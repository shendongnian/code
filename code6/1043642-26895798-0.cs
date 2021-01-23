    public GameObject ObjectHaveScript;//asign in the inspector
    void OnGUI()
    {
    String DeathCount ObjectHaveScript.GetComponent<NameOfScript>().DeathCount;
    GUI.Label ( new Rect (0, 0, 100, 100), DeathCount );
    }
    
