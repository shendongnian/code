    interface IFactory<T> where T : IFileTemplateColumn
    {
        IFileTemplate<T> Create();
    }
    class DelimitedFactory : IFactory<DelimitedFileTemplateColumn>
    {
        IFileTemplate<DelimitedFileTemplateColumn> Create() 
        {
            return new DelimitedFileTemplate();
        }
    }
