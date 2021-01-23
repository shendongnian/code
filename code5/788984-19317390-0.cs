    [ConfigurationCollection(typeof(Question))]
    public class QuestionCollection : ConfigurationElementCollection
    {   
    
        public override bool IsReadOnly()
        {
            return false;
        }
        
        protected override ConfigurationElement CreateNewElement()
        {
            return new Question();
        }
        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((Question)element).id;
        }
        public Question this[int id]
        {
            get
            {
               return this.OfType<Question>().FirstOrDefault(item => item.id == id);
            }
        }
    }
