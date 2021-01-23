    class TempObj: IEquatable<TempObj>
    {
        public string Key { get; set; }
        public object Item { get; set; }
        public bool Equals(TempObj other)
        {
            return Key.Equals(other.Key);
        }
        public override int GetHashCode()
        {
            return Key.GetHashCode();
        }
    }
    var listOrig = OriginalList.Select(x => new TempObj(
        x..CallByName(iOriginalPropertyName).ToString());
    var listNew = NewList.Select(x => new TempObj(
        x.CallByName(iNewPropertyName).ToString());
