    public class DescriptionMaster{
        [PrimaryKey]
        public int Id {get;set;}
        public string Type {get;set;}
    }
    public class ActionDescriptionMaster{
        [PrimaryKey]
        public int Id {get;set;} (FK to DescrptionMaster.Id)
        public int Code {get;set;}
        public string Description {get;set;}
    }
    public class Action{
        public int Id;
        [ForeignKey("ActionDescrptionMasterId")]
        public ActionDescrptionMaster {get;set;}
    }
