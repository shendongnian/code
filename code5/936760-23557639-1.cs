    interface IVmConvertible
    {
        IVmConvertible Model { get; set; }
        IEntity ConvertToModel(IVmConvertible target);
        IVmConvertible ConvertToViewModel(IVmConvertible target);
    }
