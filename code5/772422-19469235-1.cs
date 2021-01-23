    namespace Riogrande
    {
        public class MyLog
        {
            private static int MaximAcceptedLevel = 5;
            private static string lastMethodName = string.Empty;
            private static string filePath = "log.txt";
    
            public static void Log(string namespaceName, string className, string methodName, int logLevel)
            {
                if (logLevel < MaximAcceptedLevel)
                using (StreamWriter w = File.AppendText(filePath))
                {
                    string namespceName = className.Substring(0, className.LastIndexOf('.')).Replace('.', '_');
    
                    if (className.Contains('.'))
                    {
                        className = className.Substring(className.LastIndexOf('.') + 1);
                    }
                    if (className.Contains('+'))
                    {
                        className = className.Substring(0, className.LastIndexOf('+'));
                    }
                    className = className.Replace('.', '_');
                    string cls = "";
                    for (int i = className.Length-1; i > -1; i--)
                    {
                        if (Char.IsUpper(className[i]))
                        {
                            if (cls.Length < 3)
                            {
                                cls = className[i] + cls;
                            }
                        }
                    }
                    string currentMethodName = methodName.Replace('.', '_') + "_" + cls;
                    w.WriteLine("subgraph cluster_" + namespceName + " { node [style=filled]; label = \"" + namespceName + "\"; color=red	");
                    w.WriteLine("subgraph cluster_" + className + " { node [style=filled]; " + currentMethodName + "; label = \"" + className + "\"; color=blue	}}");
                    if (!string.IsNullOrEmpty(lastMethodName))
                    {
                        w.WriteLine(lastMethodName + " -> " + currentMethodName + ";");
                    }
                    lastMethodName = currentMethodName;
                }
            }
    
            public static void Reset()
            {
                File.Delete(filePath);
                using (StreamWriter w = File.AppendText(filePath))
                {
                    w.WriteLine("digraph G{arrowsize=2.0; ratio=fill; node[fontsize=24];graph [fontsize=24] edge [fontsize=24] node [fontsize=24] ranksep = 1.5 nodesep = .25 edge [style=\"setlinewidth(3)\"]; ");
                    w.WriteLine();
                }
            }    
        }
    }
