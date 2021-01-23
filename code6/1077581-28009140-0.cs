    class CachedPathEqualityComparer : IEqualityComparer<CachedPath> {
        public bool Equals(CachedPath a, CachedPath b) {
            return a.Actor == b.Actor
                && a.From == b.From
                && a.To == b.To;
        }
        public int GetHashCode(CachedPath p) {
            return 31*31*p.Actor.GetHashCode()+31*p.From.GetHashCode()+p.To.GetHashCode();
        }
    }
    ...
    var _cachedPaths = new Dictionary<CachedPath,CachedPath>(new CachedPathEqualityComparer());
    ...
    CachedPath cached;
    if (_cachedPaths.TryGetValue(self, out cached)) {
        ...
    }
