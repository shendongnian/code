    // ############################################################################
    // #                                                                          #
    // #        ---==>  T H I S  F I L E  I S   G E N E R A T E D  <==---         #
    // #                                                                          #
    // # This means that any edits to the .cs file will be lost when its          #
    // # regenerated. Changes should instead be applied to the corresponding      #
    // # template file (.tt)                                                      #
    // ############################################################################
    namespace ModelGenerator
    {
        /// <summary>
        /// Repository interface for CUS_Customer
        /// </summary>
        partial interface ICUS_CustomerRepository : IRepository<CUS_Customer>
        {
        }
        /// <summary>
        /// Repository class for CUS_Customer
        /// </summary>
        partial class CUS_CustomerRepository : RepositoryBase<CUS_Customer>, ICUS_CustomerRepository
        {
        }
        /// <summary>
        /// Poco class for CUS_Customer
        /// </summary>
        partial class CUS_Customer
        {
            public System.Int64                             CUS_ID                                  { get; set; }
            public System.String                            CUS_FirstName                           { get; set; }
            public System.String                            CUS_LastName                            { get; set; }
            public System.DateTime                          CUS_Born                                { get; set; }
            public System.DateTime                          CUS_Created                             { get; set; }
        } 
        /// <summary>
        /// Command class for CUS_Customer
        /// </summary>
        partial class CUS_CustomerCommand : CommandBase, ICommand
        {
            public System.Int64                             CUS_ID                                   { get; set; }
            public System.String                            CUS_FirstName                            { get; set; }
            public System.String                            CUS_LastName                             { get; set; }
            public System.DateTime                          CUS_Born                                 { get; set; }
            public System.DateTime                          CUS_Created                              { get; set; }
 
        }
        /// <summary>
        /// Command handler class for CUS_Customer
        /// </summary>
        partial class CUS_CustomerCommandHandler : ICommandHandler<CUS_CustomerCommand>
        {
            private readonly IUsersRepository _repository;
            private readonly IUnitOfWork _unitOfWork;
            public CUS_CustomerCommandHandler(IUsersRepository repository, IUnitOfWork unitOfWork)
            {
                _repository = repository;
                _unitOfWork = unitOfWork;
            }
            public ICommandResult Execute(CUS_CustomerCommand command)
            {
                CUS_Customer entity;
                if (command.CUS_ID == 0)
                {
                    entity = AutoMapper.Mapper.Map<CUS_Customer>(command);
                    _repository.Add(entity);
                }
                else
                {
                    entity = _repository.Get(x=>x.UserId==command.CUS_ID);
                    entity = AutoMapper.Mapper.Map<CUS_Customer>(command);
                    _repository.Update(entity);
                }
                _unitOfWork.Commit(command.CUS_ID);         
                return new CommandResult(true,entity.CUS_ID);
            }
        }
    }
