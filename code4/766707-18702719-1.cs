    public string ProgramName
    {
        get { return programName; }
        private set {
            if (value == "Army")
                throw new ZorgConfigurationException("Error");
            programName = value;
        }
    }
    public string Num
    {
        get { return num; }
        private set {
            int i;
            if (!Int32.TryParse(value, out i))
                throw new ZorgConfigurationException("value should be a number");
            num = value;
        }
    }
    public string File1 
    {
        get { return file1; }
        private set {
            if (!File.Exists(value))
                throw new ZorgConfigurationException("file 1 does not exist");
            file1 = value;
        }         
    }
