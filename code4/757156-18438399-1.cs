    public interface IApprove {
        bool Approved { get; set; }
        // etc
    }
    public class Student : Person, IApprove {
    }
