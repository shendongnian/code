    public class ContractRepository : BaseRepository<ContractDAL, Contract>
    {
        protected override IQueryable<Contract> GetIQueryable()
        {
            return dbSet
                .Select(entity => new Contract()
                {
                    // We cannot use AutoMapper here, because Entity Framework
                    // won't be able to process the expression. Hence manual
                    // mapping.
                    Id = entity.Id,
                    CompanyId = entity.CompanyId,
                    ProjectId = entity.ProjectId,
                    IndexNumber = entity.IndexNumber,
                    ContractNumber = entity.ContractNumber,
                    ConclusionDate = entity.ConclusionDate,
                    Notes = entity.Notes
                });
        }
        public ContractRepository(MyDbContext context)
            : base(context, context.Contracts)
        {
        }
    }
