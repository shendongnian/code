    public interface IAlgorithm<out T> where T : IParams
    {
        /// <summary>
        /// Contains algorythm parameters
        /// </summary>
        T Params{ get; }
    }
