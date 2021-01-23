    string name = "name" ;
    string names = "names";
    string named = "named";
    string nameds = "nameds";
    string[] strArray = new string[] { name, names, named, nameds };
    for (int i = 0; i < strArray.Length; i++)
    {
       MessageBox.Show(strArray[i].ToString());
    }
