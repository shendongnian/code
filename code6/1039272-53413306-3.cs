    public class ResimORM : ORMBase<Resim, mdlOgrenciKulup>, IDisposable
    {
        public void Dispose() { GC.SuppressFinalize(this); }
    }
  
    ResimORM RE_ORM = new ResimORM();
    List<Resim> a = RE_ORM.GetSqlQuery<Resim>(sql,null).ToList();
    int b = RE_ORM.GetSqlQuery<int>(sql,null).FirstOrDefault();
