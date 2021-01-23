    public class ImplementCmd : OverridedBaseCmd
    {
        object content = null;
        object OverridedBaseCmd.Content
        {
            get { return this.content; }
        }
        object BaseCmd.Content
        {
            get
            {
                return this.content;
            }
            set
            {
                this.content = value;
            }
        }
    }
