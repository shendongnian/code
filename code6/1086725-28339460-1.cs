    public class OptionsController : ApiController
    {
        private ResourceManager _resourceManager;
        private CultureInfo _cultureInfo;
        [HttpGet]
        [Route("api/Options/{type}")]
        public List<ListItem> List(string type)
        {
            _resourceManager = new ResourceManager("Application.Resources.RESOURCE", typeof(APPLICATION).Assembly);
            _cultureInfo = new CultureInfo(Application.CurrentSession.User.LanguageSelected);
            switch (type.ToUpper())
            {
                case "GENDER": return Gender();
                ...
            }
            return new List<ListItem>();
        }
        private List<ListItem> Gender()
        {
           
            var items = new List<ListItem>
            {
                new ListItem(_resourceManager.GetString("Label_Gender_Male", _cultureInfo),Domain.Enums.Gender.Male.ToString()),
                new ListItem(_resourceManager.GetString("Label_Gender_Female", _cultureInfo), Domain.Enums.Gender.Female.ToString()),
            };
            return items;
        
        }
    }
