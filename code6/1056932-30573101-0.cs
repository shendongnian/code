    [Designer(typeof(YourUserControl.Designer))]
    public partial class YourUserControl : UserControl
    #region Designer - Friend class
        /// <summary>
        /// Exposes the internal panel as content at design time, 
        /// allowing it to be used as a container for other controls.
        /// 
        /// Adapted
        /// From: How can I drop controls within UserControl at Design time?
        /// Link: http://blogs.msdn.com/b/subhagpo/archive/2005/03/21/399782.aspx
        /// </summary>
        internal class Designer : ParentControlDesigner
        {
            public override void Initialize(IComponent component)
            {
                base.Initialize(component);
                var parent = (YourUserControl)component;
                EnableDesignMode(parent.Content, "Content");
            }
        }
        #endregion
