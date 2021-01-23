    <uc1:MyGenericControl runat="server" id="MyGenericControl1" ControlType="DropDownList"  />
    public partial class MyGenericControl<T> : System.Web.UI.UserControl
    {
        public enum ucType : ushort
        {
            DropDownList = 1,
            TextBox,
            Button,
            Etc
        }
        private ucType _controlType;
        public ucType ControlType
        {
            get{return _controlType;}
            set{ T = value; } /* Somehow set T to the value set in ASP */
        }
    }
