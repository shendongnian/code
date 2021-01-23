    private static void Main(string[] args)
    {
        List<PaintMachineInfo> info = GenerateInfo();
        var filteredResults = info.ToLookup(line => new PaintMachineLookup(line.MachineName, line.Pass), line => line.ColorName);
        //Contains a IEnumerable<string> containing the elements "Color1" and "Color3"
        var result1 = filteredResults[new PaintMachineLookup("Machine 1", "Pass 1")];
    }
    private static List<PaintMachineInfo> GenerateInfo()
    {
        //...
    }
    class PaintMachineInfo
    {
        public string ColorName { get; set; }
        public string MachineName { get; set; }
        public string Pass { get; set; }
    }
    internal class PaintMachineLookup
    {
        public PaintMachineLookup(string machineName, string pass)
        {
            MachineName = machineName;
            Pass = pass;
        }
        public string MachineName { get; private set; }
        public string Pass { get; private set; }
        public override int GetHashCode()
        {
            unchecked
            {
                int x = 27;
                x = x * 11 + MachineName.GetHashCode();
                x = x * 11 + Pass.GetHashCode();
                return x;
            }
        }
        public override bool Equals(object obj)
        {
            var other = obj as PaintMachineLookup;
            if (other == null)
                return false;
            return MachineName.Equals(other.MachineName) && Pass.Equals(other.Pass);
        }
    }
