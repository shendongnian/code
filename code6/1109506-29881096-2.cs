        public class KeyphraseApiController : UmbracoAuthorizedJsonController
        {
            public IEnumerable<Keyphrase> GetAll()
            {
                var query = new Sql().Select("*").From("keyphrase");
                return DatabaseContext.Database.Fetch<Keyphrase>(query);
            }
            public Keyphrase GetById(int id)
            {
                var query = new Sql().Select("*").From("keyphrase").Where<Keyphrase>(x => x.Id == id);
                return DatabaseContext.Database.Fetch<Keyphrase>(query).FirstOrDefault();
            }
            public Keyphrase PostSave(Keyphrase keyphrase)
            {
                if (keyphrase.Id > 0)
                    DatabaseContext.Database.Update(keyphrase);
                else
                    DatabaseContext.Database.Save(keyphrase);
                return keyphrase;
            }
            public int DeleteById(int id)
            {
                return DatabaseContext.Database.Delete<Keyphrase>(id);
            }
        }
