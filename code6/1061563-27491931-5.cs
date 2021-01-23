    public class Progressor
    {
        private Lazy<string> _first = new Lazy<string>(GetMyString);
        private string _second = _first.Value;
        private string GetMyString()
        {
            // pick one from above examples
        }
    }
