    public interface IRecruiter
    {
        string Name { get; }
    }
    
    public class Recruiter : IRecruiter
    {
        public Recruiter(string name)
        {
            Name = name;
        }
        public string Name { get; private set; }
    }
