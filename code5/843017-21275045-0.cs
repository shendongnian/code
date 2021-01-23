    public abstract class AppPage : System.Web.UI.Page, IMasterContract
    {
        public string IMasterContract.Title {
            get
            {
                if(this.Master!=null && this.Master is IMasterContract)
                {
                    return ((IMasterContract)this.Master).Title;
                }
                else
                {
                    //return the title from whatever control or variable you've stored it in
                }
            }
            set
            {
                if(this.Master!=null && this.Master is IMasterContract)
                {
                    ((IMasterContract)this.Master).Title = value;
                }
                else
                {
                    //set the title to whatever control or variable you want to stored it in
                }
            }
        }
    }
