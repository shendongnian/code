    public interface IGateKeeper
    {
        /// <summary>
        /// Check if the given id is allowed to enter.
        /// </summary>
        /// <param name="id">id to check.</param>
        /// <param name="age">age to check</param>
        /// <returns>A value indicating whether the id is allowed to enter.</returns>
        bool CanEnter(string id, int age);
        ... other deep needs ...
    }
