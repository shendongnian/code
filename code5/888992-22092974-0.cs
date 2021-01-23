    public delegate bool BoolDelegate();
    public delegate bool GetAllCheckedItemsDelegate(out int[] cTypes, out int[] cFiles);
    public bool GetAllCheckedItems(out int[] cTypes , out int[] cFiles ) 
    {
        if (ListView.InvokeRequired)
        {
              int[] cTypesHelpVar = new int[0];
              int[] cFilesHelpVar = new int[0];
              bool ret = (bool)ListView.Invoke((BoolDelegate) (() => GetAllCheckedItems(out cTypesHelpVar, out cFilesHelpVar)));
    
              cTypes = cTypesHelpVar;
              cFiles = cFilesHelpVar;
    
              return ret;
        }
        else
        {
              cTypes = new int[ListView.CheckedItems.Count];
              cFiles = new int[ListView.CheckedItems.Count];
              for (int i = 0; i < ListView.CheckedItems.Count; i++)
              {
                    //.... code ....
              }
              return (ListView.CheckedItems.Count > 0);
        }
    }
