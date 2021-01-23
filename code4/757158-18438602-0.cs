      // Interfaces:
    
      // General person
      public interface IPerson {
        int Id { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string Type { get; set; }
      }
    
      // Approvable person
      public interface IApprovable {
        bool Approved { get; set; }
        DateTime ApprovedDate { get; set; }
        int ApprovedUserId { get; set; }
      } 
    
      // Student is a IPerson + IApprovable
      public interface IStudent: IPerson, IApprovable {
        DateTime DateOfBirth { get; set; }
        DateTime EnrollmentDate { get; set; }
      }
    
      // So classes will be
      
      public class Approve: IApprovable {
        ... //TODO: Implement IApprovable interface here
      } 
    
      public class Faculty: IPerson, IApprovable {
        public DateTime HiredDate { get; set; }
    
        ... //TODO: Implement IPerson interface here
        ... //TODO: Implement IApprovable interface here
      }
    
      public class Student: IStudent {
        public string Remarks { get; set; }
    
        ... //TODO: Implement IStudent interface here
      }
