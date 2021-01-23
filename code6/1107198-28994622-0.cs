    set Folder = Application.ActiveExplorer.CurrentFolder
    set Table = Folder.GetTable("[MessageClass] = 'IPM.Contact' ")
    Table.Columns.Add("EntryID")
    while not Table.EndOfTable
      set Row = Table.GetNextRow()
      vEntryId = Row.Item(1)
      Debug.Print vEntryId
    wend
 
