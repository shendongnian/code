    public delegate void Update_Table_Delegate(); //already declared
    public event Update_Table_Delegate Changed; //declare event
    //invoke event
    public void OnChanged()
    {
       if(Changed != null)
         Changed();
    }
