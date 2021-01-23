    if (!IsWriteEnabled || !IsReadEnabled) //Committing transactions closes everything for reading and writing so it must be reopened
    {
        tr.GetObject(this.ObjectId, OpenMode.ForRead);
        tr.GetObject(this.ObjectId, OpenMode.ForWrite);
    }
