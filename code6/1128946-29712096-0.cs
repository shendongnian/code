    public class GetPractices : IReturn<PracticesResponse> 
    {
        public string Source { get; set; }
    }
    public object Get(GetPractices request)
    {
        return new PracticesResponse {
            Practices = Repo.GetBySource(request.Source)
        };
    }
