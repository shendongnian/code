     public abstract class MemberWebPage : System.Web.UI.Page
    {
        public virtual bool AutorizeUser()
        {
            return false;
        }
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
        }
    }
