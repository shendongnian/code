    public class DBReferenceAttribute : Attribute
    {
        public DBReferenceAttribute(string guid)
        {
            this.Guid = new Guid(guid);
        }
        public Guid Guid { get; set; }
    }
    class UserInfo
    {
        [DBReference(idInDB1)]
        string member1;
        string member2;
        string member3;
        const string idInDB1 = "000";
    }
