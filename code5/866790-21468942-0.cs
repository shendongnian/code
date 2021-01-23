    timedEvQue.Add(3, "First");
    timedEvQue.Add(7, "Second");
    timedEvQue.Add(9, "Third");
    int decAmnt = (int)timedEvQue.Keys[0];
    timedEvQue.RemoveAt(0);
    for (int i = 0; i < timedEvQue.Count; ++i)
    {
        int oldKey = timedEvQue.Keys[i];
        string val = timedEvQue[oldKey];
        int newKey = oldKey - decAmnt;
        timedEvQue.Remove(oldKey);
        timedEvQue.Add(newKey, val);
    }
    timedEvQue.Add(5, "Forth");
