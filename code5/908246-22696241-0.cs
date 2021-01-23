    public partial class MessageSource
    {
    private string _defaultLanguage;
    public MessageSource(string defaultLang)
    {
        this.messages = new HashSet<Message>();
        this._defaultLanguage = defaultLanguage ;
    }
    public int id { get; set; }
    public string category { get; set; }
    public string message { get; set; }
    public string message_translation { get; 
    set{ value = getTranslation(_defaultLnag); }
    public virtual ICollection<Message> messages { get; set; }
    public string getTranslate(string lang)
    {
        
             var Translation = dbcontext.messages.Where(m=> m.Id == this.Id).FirstOrDefault().Translation.Where(t=>t.lang == lang).FirstOrDefault();
        return Translation;
     }
    }
