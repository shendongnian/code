    using System.Web.UI;
    using System.Web.UI.WebControls;
    
    public class MinHeightStyle : Style
    {
        public Unit MinHeight
        {
            get
            {
                var minHeight = this.ViewState["MinHeight"];
    
                if (minHeight != null)
                {
                    return (Unit)minHeight;
                }
    
                return Unit.Empty;
            }
    
            set
            {
                this.ViewState["MinHeight"] = value;
            }
        }
    
        protected override void FillStyleAttributes(CssStyleCollection attributes, IUrlResolutionService urlResolver)
        {
            base.FillStyleAttributes(attributes, urlResolver);
    
            if (!this.MinHeight.IsEmpty)
            {
                attributes.Add("min-height", this.MinHeight.ToString());
            }
        }
    }
