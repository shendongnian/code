    for (int index = 0; index < animalmgr.ElementCount; index++)
    {
        Animal animal = animalmgr.GetElementAtPosition(index);
        Resultlst.Items.Add(animal);
    }
    Resultlst.DisplayMember = "Name";  // or whatever property of your class is appropriate
