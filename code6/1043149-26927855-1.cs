    public class processorM1Ver1 : IProcessMessage
    {
        public string ProcessMessage(string message)
        {
            ResultObject1 ro1 = processM1MessageVer1(message);
            var result = serialize(ro1);
            result = convertToB64(result);
            return result;
        }
        public string ActionVersion {get { return "m1"; }}
        public string AlgorithmVersion {get { return "ver1"; }}
    }
    public class processorM2Ver1 : IProcessMessage
    {
        public string ActionVersion {get { return "m2"; }}
        public string AlgorithmVersion {get { return "ver1"; }}
        public string ProcessMessage(string message)
        {
            ResultObject1 ro1 = processM2MessageVer1(message);
            var result = serialize(ro1);
            result = convertToB64(result);
            return result;
        }
    }
    public class processorM1Ver2 : IProcessMessage
    {
        public string ActionVersion {get { return "m1"; }}
        public string AlgorithmVersion {get { return "ver2"; }}
        public string ProcessMessage(string message)
        {
            ResultObject1 ro1 = processM1MessageVer2(message);
            var result = serialize(ro1);
            result = convertToB64(result);
            return result;
        }
    }
