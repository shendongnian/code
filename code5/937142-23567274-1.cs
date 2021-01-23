    protected Hashtable Active_Frozen(string text, string color)
    {
         // code code
        Hashtable values = new Hashtable();
        if(query=="true")
        {
           values.Add("text", "Active");
           values.Add("color", "Green";
        }
        else
        {
            // etc
        }
        
        return values;
    }
    protected void Active_Frozen(out string text, out string color)
    {
        // this way, whenever you modify text or color, you will modify the actual instances you passed to Active_Frozen instead of copies
        // and code code
    }
