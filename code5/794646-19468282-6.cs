    [DataContract(IsReference=true)]
    public partial class Employee
    {
       [DataMember]
       string dfsd{get;set;}
       [DataMember]
       string dfsd{get;set;}
       //exclude  the relation without giving datamember tag
       List<Department> Departments{get;set;}
    }
