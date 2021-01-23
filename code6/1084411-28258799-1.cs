        public class Encoding
        {
            private Char _C;
            private List<int> _Positions;
            private Encoding() {}
            public Encoding(Char C)
            {
                this._C = C;
                this._Positions = new List<int>();
            }
            public Char Character
            {
                get
                {
                    return _C;
                }
            }
            public int Count
            {
                get
                {
                    return _Positions.Count;
                }
            }
            public int[] Occurences
            {
                get
                {
                    return _Positions.ToArray();
                }
            }
            public override string ToString()
            {
                string[] values = Array.ConvertAll(this.Occurences.ToArray(), x => x.ToString());
                return this.Character.ToString() + this.Count.ToString() + "[" + String.Join(",", values) + "]";
            }
            public void AddOccurence(int position)
            {
                this._Positions.Add(position);
            }
        }
