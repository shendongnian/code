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
    
        public Question GetQuestion(int id)
        {
            return (Question)this.BaseGet(id);
        }
    
    }
