    public class CompanyModel : ModelObject<CompanyModel, CompanyDataCore, int>
    {
        [Identifier]
        [DataCoreMember(MemberName="ID")]
        public int? ID { get { return dataCore.ID; } set { SetProperty(ref dataCore.ID, value); } }
        [DataCoreMember(MemberName="Name")]
        public string Name { get { return dataCore.Name; } set {SetProperty(ref dataCore.Name, value); } }
        
        [DataCoreMember(MemberName="Code")]
        public string Code { get { return dataCore.Code; } set { SetProperty(ref dataCore.Code, value); } }
        
        [DataCoreMember(MemberName="PrimaryPhone")]
        public string PrimaryPhone { get { return dataCore.PrimaryPhone; } set {SetProperty(ref dataCore.PrimaryPhone, value); } }
        
        [DataCoreMember(MemberName="PrimaryEmail")] 
        public string PrimaryEmail { get { return dataCore.PrimaryEmail; } set { SetProperty(ref dataCore.PrimaryEmail, value); } }
        
        [DataCoreMember(MemberName="PrimaryWebsite")]
        public string PrimaryWebsite { get { return dataCore.PrimaryWebsite; } set { SetProperty(ref dataCore.PrimaryWebsite, value); } }
    
    }
