    public StringBuilder generateString(List<object> objList)
    {
        StringBuilder sb = new StringBuilder();
        int itemNumber = 0;
        foreach(var obj in objList)
        {
            foreach (var prop in obj.GetType().GetProperties())
            {
                  // i used the new line characters to increase readability for 
                  // output to a console so just ignore them.
                  sb.Append("Item " + itemNumber);
                  sb.Append("\n");
                  sb.Append(prop.Name + ", " + prop.GetValue(obj, null));            
                  sb.Append("\n");
             }
        }
        return sb;
    }
