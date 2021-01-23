    using System.Text; // <-- add this
    // inside the code
    
    for(i = 0 ; i <= ArrayList.Count ; i++ )
    {
       string TEST = Encoding.UTF8.GetString(ArrayList[i]);
    }
