    public class FormatZipper {
        //This could be two lists, but it's probably more space/time efficent to use a single list. 
        List<Tuple<string,object>> _entries;
        StringBuilder _builder;
        public FormatZipper() {
            _builder = new StringBuilder();
            _entries = new List<Tuple<string, object>>();
        }
        public void AddEntry(string fmt, object data) {
            _entries.Add(Tuple.Create(fmt, data));
        }
        
        public string CurrentString {
            get {
                _builder.Clear();
                foreach (var entry in _entries) {
                    _builder.AppendFormat(entry.Item1, entry.Item2);
                }
                return _builder.ToString();
            }
        }
    }
    class Program {
        static void Main(string[] args) {
            FormatZipper zipper = new FormatZipper();
            zipper.AddEntry("{0:F1},", 1);
            Console.WriteLine(zipper.CurrentString);
            zipper.AddEntry("{0:F2,", 1);
            Console.WriteLine(zipper.CurrentString);
            
        }
    }
