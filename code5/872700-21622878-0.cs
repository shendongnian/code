    // ...
    SetFormattedValue(ref cmd, node.ID);
    // ...
    private void SetFormattedValue(ref IDBCommand cmd, int id) // IDBCommand - or whatever your command type is
    {
        if(node.ID==0)
        {
            cmd.Parameters["@ID"].Value = DBNull.Value;
        }
        else
        {
            cmd.Parameters["@ID"].Value = node.ID;
        }
    }
