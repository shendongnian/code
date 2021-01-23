    var doorDatas = db.vwDockDoorDatas.Where(x => x.DockNo >= 1 && x.DockNo <= 11)
                                      .ToList();
    for (int i = 0; i < doorDatas.Count; i++)
    {
        // This is where the Stack Trace is pointing to.
        DockDoorViewModel door = data.ToDockDoorViewModel();
        if (door == null)
        {
            door = new DockDoorViewModel(i+1);
        }
        else
        {
            door.Items = data.ToDockDoorItem();
        }
        doors.Add(door);
    }
