        public interface IProcessMessage
        {
            string ActionVersion { get; }
            string AlgorithmVersion { get; }
            string ProcessMessage(string message);
        }
