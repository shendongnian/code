    interface IFileTemplate { ... }
    interface IFileTemplate<T> : IFileTemplate where T : IFileTemplateColumn
    {
        List<IFileTemplateColumn> Columns { get; set; }
    }
