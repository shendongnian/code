    public class DtoModel
        {
            public string Action { get; set; }
            public string Controller { get; set; }
            public string Name { get; set; }
        }
    public string Index(DtoModel baseModel)
        {
            var names=string.Format("Controller : {0}, Action: {1}",baseModel.Controller,baseModel.Action);
            return names;
        }
