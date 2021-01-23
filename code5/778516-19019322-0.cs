    public class WizardPage
    {
       public virtual string PageTitle { get; }
       ...
    }
    
    public class WizardPage1 : WizardPage
    {
       public override string PageTitle
       {
          get 
          {
              return getLocalizedString(this.GetType(), "PageTitle");
          } 
       }
    }
