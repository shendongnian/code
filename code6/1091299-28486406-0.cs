    using System;
    using System.IO;
    using System.Reflection;
    ...
    string thisAsmFile = Assembly.GetExecutingAssembly().Location;
    string thisAsmDir = Path.GetDirectoryName(thisAsmPath);
    string highScoreFile = Path.Combine(thisAsmDir, "scores.txt");
