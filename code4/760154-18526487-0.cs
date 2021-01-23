    public class MemberData
    {
        List<MemberBasicData> BasicData {get;set;}
        List<MemberDetail> Details {get;set;}
    }
    
    public MemberData GetMemberProfile()//I Know this is wrong
    {
             ............//dbcodes
    
      return new MemberData(){BasicData=list1, Details=list2};
    }
