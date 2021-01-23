        public class VToken : CommonToken
    {
        public IModelTreeNode ModelTreeNode;
        public bool IsRecognized;
        public string[] Completions;
        public VToken(int type, String text) : base(type, text)
        {
        }
        public VToken(Tuple<ITokenSource, ICharStream> source, int type,
            int channel, int start, int stop) : base(source, type, channel, start, stop)
        {
        }
        public override string ToString()
        {
            return "VToken : " + Text;
        }
    }
