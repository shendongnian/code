    [StructLayout(LayoutKind.Sequential)]
    public struct SConfig {
        public int Parameter;
        public int Value;
    }
    [StructLayout(LayoutKind.Sequential)]
    public struct SConfig_List {
        public int NumOfParams;
        public SConfig[] sconfig;
        public SConfig_List(List<SConfig> param) {
            this.NumOfParams = param.Count;
            this.sconfig = new SConfig[param.Count];
            param.CopyTo(this.sconfig);
        }
    }
