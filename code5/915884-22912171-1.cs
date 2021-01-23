    public class TermWithOffsetsView : AnalyzerView {
        public override string Name {
            get { return "Terms With Offsets"; }
        }
        protected override string GetTokenView(TokenStream tokenStream) {
            ITermAttribute termAtt = tokenStream.AddAttribute<ITermAttribute>();
            IOffsetAttribute offsetAtt=tokenStream.AddAttribute<IOffsetAttribute>();
            return string.Format("{0}   Start: {1}  End: {2}{3}",
                termAtt.Term,
                offsetAtt.StartOffset.ToString().PadLeft(5),
                offsetAtt.EndOffset.ToString().PadLeft(5),
                Environment.NewLine);
        }
    }
