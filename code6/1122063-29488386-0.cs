    public class BOMemberSeletedId
    {
        public List<int> MemberSeletedId { get; set; }
    }
    BOMemberSeletedId param = js.Deserialize<BOMemberSeletedId>(jsonString);
    List<int> values = param.MemberSeletedId;
    ...
