    public partial class ShowCase : System.Web.UI.UserControl, IComponent
    {
        protected void Page_Load(object sender, EventArgs e){}
        public void ApplyConfiguration(IConfiguration configuration)
        {
            throw new NotImplementedException();
        }
    }
    public interface IComponent
    {
        void ApplyConfiguration(IConfiguration configuration);
    }
    public abstract class Decorator : IComponent
    {
        protected ShowCase ShowCase;
        protected Decorator(ShowCase showcase)
        {
            ShowCase = showcase;
        }
        public virtual void ApplyConfiguration(IConfiguration configuration)
        {
            ShowCase.ApplyConfiguration(configuration);
        }
    }
    public class ShowCaseDecoratorA : Decorator
    {
        public ShowCaseDecoratorA(ShowCase showcase) : base(showcase){ }
        public override void ApplyConfiguration(IConfiguration configuration)
        {
            base.ApplyConfiguration(configuration);
            //depending on the configuration, do something..
            ShowCase.Visible = false;
        }
    }
    public interface IConfiguration
    {
        //configuration
    }
