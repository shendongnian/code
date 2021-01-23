    #region MovieDTO
    [Api("GET Movie by Id")]
    [Route("/movie/{Id}")]
    public class MovieDTORequest
    {
        public int Id { get; set; }
    }
    public class MovieDTOResponse
    {
        public MovieViewModel Movie{ get; set; }
    }
    #endregion
