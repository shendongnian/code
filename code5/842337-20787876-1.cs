    var lines = File.ReadAllLines(@"...");
    Stack<LineData> parents = new Stack<LineData>();
    List<LineData> items = new List<LineData>();
    
    foreach (string line in lines) 
    {
        string[] parts = Regex.Split(line, @"\s+");
        
        string code = parts[0];
        string title = parts[1];
        
        LineData newItem = new LineData 
        { 
            OriginalCode = code,
            Title = title
        };
        
        LineData parent = null;
        
        // Find the parent, if any.
        while (parents.Any() && parent == null)
        {
            LineData temp = parents.Peek();
            
            if (code.Replace("0", string.Empty).Contains(
                temp.OriginalCode.Replace("0", string.Empty)))
            {
                parent = temp;
            }
            else
            {
                parents.Pop();
            }
        }
        
        if (parent != null)
        {
            parent.Children.Add(newItem);
        }
        else 
        {
            items.Add(newItem);
        }
        
        parents.Push(newItem);
    }
