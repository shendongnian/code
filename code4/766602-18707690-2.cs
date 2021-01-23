    using UnityEngine;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    public static class ClassFileFinder
    {
    static List<string> classFiles;
    public static ClassFileDetails FindClassFile(System.Type t)
    {
        return FindClassFile(t.Name);
    }
    public static ClassFileDetails FindClassFile(string className)
    {
        ClassFileDetails details = DatabaseLink.GetClassFileDetails(className);
        if (details == null)
        {
            //Lookup class name in file names
            classFiles = new List<string>();
            FindAllScriptFiles(Application.dataPath);
            Debug.Log(classFiles.Count);
            for (int i = 0; i < classFiles.Count; i++)
            {
                if (classFiles[i].Contains(className))
                {
                    details = new ClassFileDetails(className, classFiles[i],    File.GetLastAccessTimeUtc(classFiles[i]));
                }
            }
            //Lookup class name in the class file text 
            if (details == null)
            {
                for (int i = 0; i < classFiles.Count; i++)
                {
                    string codeFile = File.ReadAllText(classFiles[i]);
                    if (codeFile.Contains("class " + className))
                    {
                        details = new ClassFileDetails(className, classFiles[i], File.GetLastAccessTimeUtc(classFiles[i]));
                    }
                }
            }
            if (details == null)
            {
                Debug.LogWarning("Failed to lookup class file for class " + className);
            }
            return details;
        }
        else
        {
            return details;
        }
    }
         static void FindAllScriptFiles(string startDir)
        {
       try
       {
           foreach (string file in Directory.GetFiles(startDir))
           {
               if (file.Contains(".cs") || file.Contains(".js"))
                   classFiles.Add(file);
           }
           foreach (string dir in Directory.GetDirectories(startDir))
           {
               FindAllScriptFiles(dir);
           }
       }
       catch (System.Exception ex)
       {
           Debug.Log(ex.Message);
       }
       }
    }
    public class ClassFileDetails
    {
    public int OID { get; set; }
    public string className { get; set; }
    [Sqo.Attributes.UniqueConstraint]
    public string path { get; set; }
    public System.DateTime updateTime { get; set; }
    internal ClassFileDetails()
    { }
    internal ClassFileDetails(string setClassName, string setPath, System.DateTime setUpdateTime)
    {
        className = setClassName;
        path = setPath;
        updateTime = setUpdateTime;
        DatabaseLink.StoreClassFileDetails(this);
    }
}
    
