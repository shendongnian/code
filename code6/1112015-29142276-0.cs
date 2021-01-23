    public interface IGateKeeper
    {
        /// <summary>
        /// Check if the given id is allowed to enter.
        /// </summary>
        /// <param name="id">id to check.</param>
        /// <returns>A value indicating whether the id is allowed to enter.</returns>
        bool CanEnter(string id);
        ... other deep needs ...
    }
