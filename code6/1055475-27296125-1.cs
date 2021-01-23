    class NnnnEntityFactory : IRefEntityFactory
    {
        public List<IRefEntity> Search(string sp_name, int? id, string code, int? statusid)
        {
            List<IRefEntity> ret = new List<IRefEntity>();
            ret.Add(new NnnnType());
            return ret;
        }
    }
