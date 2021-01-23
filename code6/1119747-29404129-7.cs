    for (int index = 0; index < animalmgr.ElementCount; index++)
    {
        Animal animal = animalmgr.GetElementAtPosition(index);
        Resultlst.Items.Add(animal);   // add the Animal instance; don't call ToString()
    }
    Resultlst.DisplayMember = "Name";  // whatever property of your class is appropriate
