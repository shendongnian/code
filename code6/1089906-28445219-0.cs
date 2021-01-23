    public class MyComparer : Comparer<string>
    {
        private string _alphabet1 = "irqjfomqwijapfpdpwe";
        public override int Compare(string x, string y)
        {
            var minLength = Math.Min(x.Length, y.Length);
            for (var i = 0; i < minLength; i++)
            {
                var stringXpos = _alphabet1.IndexOf(x[i]);
                var stringYpos = _alphabet1.IndexOf(y[i]);
                if (stringXpos < stringYpos)
                    return -1;
                if (stringYpos < stringXpos)
                    return 1;
            }
            return x.Length < y.Length ? -1 : (x.Length > y.Length) ? 1 : 0;
        }
    }
