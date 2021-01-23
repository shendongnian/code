    public class AnswerRepository : EntityRepositoryBase<AnswerEntity>, IAnswerRepository
    {
        public override ObjectSet<AnswerEntity> EntityCollection
        {
            get { return Context.AnswerEntities; }
        }
    }
