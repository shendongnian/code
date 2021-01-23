    public class CachedMaps
    {
        private readonly Dictionary<int, Map> _maps = new Dictionary<int, Map>();
        
        public Map GetMap(int mapId)
        {
            if (!this._maps.ContainsKey(mapId))
            {
                this._maps[mapId] = this.Add(new Map(....));
            }
            return this._maps[mapId];
        }
    }
