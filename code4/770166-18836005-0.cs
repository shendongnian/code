    <#@ include file="$(SolutionDir)\packages\T4IncludeTemplate.1.0.3\T4\Schema.ttinclude"#>
    <#
        // The namespace surrounding the code
        var namespaceName               = "ModelGenerator";
        var connectionString            = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=TestDB;Integrated Security=True";
        var schema                      = GetSchema (connectionString);
        Func<string, string> justify    = s => LeftJustify (s, 40);
        var tables                      = schema
            .SchemaObjects
            .Where (so => so.Type == SchemaObject.SchemaObjectType.Table)
            .ToArray ()
            ;
    #>
    namespace <#=namespaceName#>
    {
    <#
        foreach (var table in tables)
        {
    #>
        /// <summary>
        /// Repository interface for <#=table.Name#>
        /// </summary>
        partial interface I<#=table.Name#>Repository : IRepository<<#=table.Name#>>
        {
        }
        /// <summary>
        /// Repository class for <#=table.Name#>
        /// </summary>
        partial class <#=table.Name#>Repository : RepositoryBase<<#=table.Name#>>, I<#=table.Name#>Repository
        {
        }
        /// <summary>
        /// Poco class for <#=table.Name#>
        /// </summary>
        partial class <#=table.Name#>
        {
    <#
        foreach (var column in table.Columns)
        {
    #>
            public <#=justify (column.CsTypeName)#> <#=justify (column.Name)#>{ get; set; }
    <#
        }
    #>
        } 
        /// <summary>
        /// Command class for <#=table.Name#>
        /// </summary>
        partial class <#=table.Name#>Command : CommandBase, ICommand
        {
    <#
        foreach (var column in table.Columns)
        {
    #>
            public <#=justify (column.CsTypeName)#> <#=justify (column.Name)#> { get; set; }
    <#
        }
    #> 
        }
        /// <summary>
        /// Command handler class for <#=table.Name#>
        /// </summary>
        partial class <#=table.Name#>CommandHandler : ICommandHandler<<#=table.Name#>Command>
        {
            private readonly IUsersRepository _repository;
            private readonly IUnitOfWork _unitOfWork;
            public <#=table.Name#>CommandHandler(IUsersRepository repository, IUnitOfWork unitOfWork)
            {
                _repository = repository;
                _unitOfWork = unitOfWork;
            }
            public ICommandResult Execute(<#=table.Name#>Command command)
            {
                <#=table.Name#> entity;
    <#
        var identityColumn = table.Columns.FirstOrDefault (c => c.IsIdentity);
        if (identityColumn == null)
        {
    #>
    @@@ ERROR__NO_IDENTITY_COLUMN_FOUND_FOR: <#=table.FullName#>
    <#
        }
        else
        {
    #>
                if (command.<#=identityColumn.Name#> == 0)
                {
                    entity = AutoMapper.Mapper.Map<<#=table.Name#>>(command);
                    _repository.Add(entity);
                }
                else
                {
                    entity = _repository.Get(x=>x.UserId==command.<#=identityColumn.Name#>);
                    entity = AutoMapper.Mapper.Map<<#=table.Name#>>(command);
                    _repository.Update(entity);
                }
                _unitOfWork.Commit(command.<#=identityColumn.Name#>);         
                return new CommandResult(true,entity.<#=identityColumn.Name#>);
    <#
        }
    #>
            }
        }
    <#
        }
    #>
    }
    <#+
        static Schema GetSchema (string connectionString) 
        {
            using (var connection = new SqlConnection (connectionString))
            {
                connection.Open ();
                return new Schema (connection);
            }
        }
    #>
