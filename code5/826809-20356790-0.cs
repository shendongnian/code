    using System;
    using System.IO;
    using System.Text;
    
    string [] lines = File.ReadAllLines(PublicVariables.AddedFileName);
    Array.Resize(ref lines , lines.Length-2);
           
    File.WriteAllLines(PublicVariables.AddedFileName, lines);
