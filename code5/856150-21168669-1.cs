    interface IAddressee
    {
        int Address { get; }
        bool IsAddressChangeable { get; }
        /// <summary>
        /// If address can be changed (IsAddressChangeable == true):
        ///     - change the address
        ///     - set Address to new address
        /// 
        /// If address can not be changed (IsAddressChangeable == false):
        ///     - throw InvalidOperationException;
        /// </summary>
        void ChangeAddress(int address);
    }
    interface IDevice : IAddressee
    {
        bool IsActive { get; }
        /// <summary>
        /// If device is active (IsActive == true):
        ///     - throw InvalidOperationException;
        /// 
        /// If device is not active (IsActive == false):
        ///     - activate the device
        ///     - set IsActive to true
        ///     - set IsAddressChangeable to false
        /// </summary>
        void Activate();
        /// <summary>
        /// If device is active (IsActive == true):
        ///     - deactivate the device
        ///     - set IsActive to false
        ///     - set IsAddressChangeable to true
        /// 
        /// If device is not active (IsActive == false):
        ///     - throw InvalidOperationException;
        /// </summary>
        void Deactivate();
    }
