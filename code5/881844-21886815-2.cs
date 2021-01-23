    var frontier = new Queue<Folder>();
    foreach (Folder f in lSession.Folders)
    {
        frontier.Enqueue(f);
    }
    while (frontier.Any())
    {
        var curFolder = frontier.Dequeue();
        curFolder.Items.ItemChange += Items_ItemChange;
        foreach (Folder ch in curFolder.Folders)
        {
            frontier.Enqueue(ch);
        }
    }
            }
