    public class LimitCountAttribute : ValidationAttribute
    {
        private readonly int _min;
        private readonly int _max;
        public LimitCountAttribute(int min, int max) {
            _min = min;
            _max = max;
        }
        public override bool IsValid(object value) {
            var list = value as IList;
            if (list == null)
                return false;
            if (list.Count < _min || list.Count > _max)
                return false;
            return true;
        }
    }
