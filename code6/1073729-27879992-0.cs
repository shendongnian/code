    public  string GetDirectoryNDepth(string root, string target, int depth)
    {
        string[] splittedRoot = root.Split(Path.DirectorySeparatorChar);
        string[] splittedTarget = target.Split(Path.DirectorySeparatorChar);
    
        StringBuilder sb = new StringBuilder();
    
        for (int i = 0; i < splittedTarget.Length; i++)
             if (i < splittedRoot.Length + depth)
                sb.Append(String.Format("{0}{1}", splittedTarget[i], Path.DirectorySeparatorChar));
             else
                break;
    
        return sb.ToString(); 
    }  
