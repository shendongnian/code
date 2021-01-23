    class PicFactory {
        private readonly IDictionary<int,Pic> knownPics = new Dictionary<int,Pic>();
        public Pic GetOrCreate(int id) {
            Pic res;
            if (knownPics.TryGetValue(id, out res)) {
                return res;
            }
            res = new Pic(id.ToString()); // This assumes that Pic(string) exists
            knownPics.Add(id, res);
            return res;
        }
    }
