    public class SomeModel
    {
        public string Model {get; set;}
        public string ActiveId {get; set;}
        [AllowHtml]
        public string ContentToUpdate {get; set;}
    }
    public void SaveContent(SomeModel model)
    {
        //access model.Model, model.ActiveId and model.ContentToUpdate here
    }
