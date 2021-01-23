    interface IVmConvertible<T>
    {
        IVmConvertible Model { get; set; }
        T ConvertToModel(IVmConvertible target);
        IVmConvertible ConvertToViewModel(IVmConvertible target);
    }
