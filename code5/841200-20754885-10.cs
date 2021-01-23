    using System;
    
    namespace RepeaterTestOne
    {
        public partial class Show : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
            }
    
            protected void Button1_Click(object sender, EventArgs e)
            {
                MyDataClass.BindTable(rptDisplay, MyEnum.FirstOne);
            }
    
            protected void Button2_Click(object sender, EventArgs e)
            {
                MyDataClass.BindTable(rptDisplay,MyEnum.FirstFour);
            }
    
            protected void Button3_Click(object sender, EventArgs e)
            {
                MyDataClass.BindTable(rptDisplay, MyEnum.AllItems);
            }
        }
    }
