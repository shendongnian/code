        public abstract class EmailTemplates
        {
            protected void BuildBody()
            {
                ReplaceVariables();
            }
            protected virtual string ReplaceVariables()
            {
                //code
            }
        }
    
        public abstract class CustomerEmailTemplates : EmailTemplates
        {
            protected override string ReplaceVariables()
            {
                //code
                base.ReplaceVariables();
            }
        }
        
        public class OrderEmailTemplates : CustomerEmailTemplates
        {
            protected override string ReplaceVariables()
            {
                //code
                base.ReplaceVariables();
            }
        }
    
