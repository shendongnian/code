    public class ResimORM : ORMBase<Resim, mdlOgrenciKulup>, IDisposable
    {
        public void Dispose() { GC.SuppressFinalize(this); }
    }
    if(RE_ORM.IsNull()) { RE_ORM = new ResimORM(); }
    var a = RE_ORM.GetSqlQuery<Resim>(sql,null).ToList();
    var b = RE_ORM.GetSqlQuery<int>(sql,null).FirstOrDefault();
