    interface IAddressee
    {
        int Address { get; }
       /// <summary>
       /// Can Address be changed?
       /// </summary>
       bool IsAddessChangeable { get; };
        /// <summary>
        /// Raised when (IsAddessChangeable == true)
        /// and Address was changed
        /// </summary>
        event Action<int> AddressChanged;
    }
