    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.ServiceModel;
    using System.ServiceModel.Web;
    using System.Text;
    using System.Data.SqlClient;
    using System.Data;
    
    namespace WCFServiceForInsert
    {
        
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "IService" à la fois dans le code et le fichier de configuration.
    // There is not a reason to keep this IService unless it is necessary for some other piece of your code
    [ServiceContract]
    public interface IService
    {
    }
        // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
        [ServiceContract]
        public interface IService1
        {
            [OperationContract]
            string InsertUserDetails(UserDetails userInfo);
            [OperationContract]
            DataSet SelectUserDetails();
        }
        // Use a data contract as illustrated in the sample below to add composite types to service operations.
        // You must declare this outside of the Interface definition.
        [DataContract]
         public class UserDetails
        {
            int id;
            string title;
            string salary;
            string benefits;
            string keywords;
            string jobType;
            string location;
            string startDate;
            string description;
            string recruitmentAgency;
            string agencyContact;
            string agencyPhone;
            string agencyEmail;
            string jobRef;
            string datePosted;
            string dateExpire;
            [DataMember]
            public int JobID
            {
                get { return id; }
                set { id = value; }
            }
            [DataMember]
            public string Title
            {
                get { return title; }
                set { title = value; }
            }
            [DataMember]
            public string Salary
            {
                get { return salary; }
                set { salary = value; }
            }
            [DataMember]
            public string Benefits
            {
                get { return benefits; }
                set { benefits = value; }
            }
            [DataMember]
            public string Keywords
            {
                get { return keywords; }
                set { keywords = value; }
            }
            [DataMember]
            public string JobType
            {
                get { return jobType; }
                set { jobType = value; }
            }
            [DataMember]
            public string Location
            {
                get { return location; }
                set { location = value; }
            }
            [DataMember]
            public string StartDate
            {
                get { return startDate; }
                set { startDate = value; }
            }
            [DataMember]
            public string Description
            {
                get { return description; }
                set { description = value; }
            }
            [DataMember]
            public string RecruitmentAgency
            {
                get { return recruitmentAgency; }
                set { recruitmentAgency = value; }
            }
            [DataMember]
            public string AgencyContact
            {
                get { return agencyContact; }
                set { agencyContact = value; }
            }
            [DataMember]
            public string AgencyPhone
            {
                get { return agencyPhone; }
                set { agencyPhone = value; }
            }
            [DataMember]
            public string AgencyEmail
            {
                get { return agencyEmail; }
                set { agencyEmail = value; }
            }
            [DataMember]
            public string JobRef
            {
                get { return jobRef; }
                set { jobRef = value; }
            }
            [DataMember]
            public string DatePosted
            {
                get { return datePosted; }
                set { datePosted = value; }
            }
            [DataMember]
            public string DateExpire
            {
                get { return dateExpire; }
                set { dateExpire = value; }
            }
        }
}
