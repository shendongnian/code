    List<TYPE> objectsforupload = EntriesList.ToList();
    while (objectsforupload.Count > 0)
    {
            List<TYPE> uploadlist = objectsforupload.Take(100).ToList();
            objectsforupload = objectsforupload.Where(x => !uploadlist.Contains(x)).ToList();
            service.InsertEntries(objectsforupload);
            System.Threading.Thread.Sleep(5000);
    }
