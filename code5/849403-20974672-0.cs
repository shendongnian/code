    if(GUI.Button(new Rect(10,130,100,50), "Forward"))
    {
        if (index > 0 && object_List[index] != null)
        {
            Destroy((GameObject)object_List[index]);
        }
        Instantiate((GameObject)object_List[index]);
        index ++;
    }
