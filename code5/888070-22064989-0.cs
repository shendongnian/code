     public string GetVersion()
            {
                Version v = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
                return " v." + v.Major + "." + v.Minor + "." + v.Build + "." + v.Revision;
            }
