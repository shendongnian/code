    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Data;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    public partial class CreateRMA : System.Web.UI.Page
    {
        static int myCount = 1;
        private TextBox[] dynamicTextBoxes;
        private TextBox[] Serial_arr;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                myCount = 1;
            }
        }
        protected void Page_Init(object sender, EventArgs e)
        {
            Control myControl = GetPostBackControl(this.Page);
            if (myControl != null)
            {
                if (myControl.ID.ToString() == "btnAddTextBox")
                {
                    myCount = myCount >= 30 ? 30 : myCount + 1;
                }
                if (myControl.ID.ToString() == "btnRemoveTextBox")
                {
                    myCount = myCount <= 1 ? 1 : myCount - 1;
                }
            }
        }
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            dynamicTextBoxes = new TextBox[myCount];
            Serial_arr = new TextBox[myCount];
            int i;
            for (i = 0; i < myCount; i += 1)
            {
                LiteralControl literalBreak = new LiteralControl("<div>");
                DynamicDevices.Controls.Add(literalBreak);
                TextBox Serial = new TextBox();
                Serial.ID = "txtSerial" + i.ToString();
                Serial.CssClass = "";
                DynamicDevices.Controls.Add(Serial);
                Serial_arr[i] = Serial;
                TextBox textBox = new TextBox();
                textBox.ID = "myTextBox" + i.ToString();
                DynamicDevices.Controls.Add(textBox);
                dynamicTextBoxes[i] = textBox;
                literalBreak = new LiteralControl("</div>");
                DynamicDevices.Controls.Add(literalBreak);
            }
        }
        public static Control GetPostBackControl(Page thePage)
        {
            Control mycontrol = null;
            string ctrlname = thePage.Request.Params.Get("_EVENTTARGET");
            if (((ctrlname != null) & (ctrlname != string.Empty)))
            {
                mycontrol = thePage.FindControl(ctrlname);
            }
            else
            {
                foreach (string item in thePage.Request.Form)
                {
                    Control c = thePage.FindControl(item);
                    if (((c) is System.Web.UI.WebControls.Button))
                    {
                        mycontrol = c;
                    }
                }
            }
            return mycontrol;
        }
        protected void Submit_Click(object sender, EventArgs e)
        {
            int deviceCount = Serial_arr.Count();
        
            DataSet ds = new DataSet();
            ds.Tables.Add("Devices");
            ds.Tables["Devices"].Columns.Add("Serial", System.Type.GetType("System.String"));
            ds.Tables["Devices"].Columns.Add("text", System.Type.GetType("System.String"));
            for (int x = 0; x < deviceCount; x++)
            {
                DataRow dr = ds.Tables["Devices"].NewRow();
                dr["Serial"] = Serial_arr[x].Text.ToString();
                dr["text"] = dynamicTextBoxes[x].Text.ToString();
                ds.Tables["Devices"].Rows.Add(dr);
            }
            //MyLabel.Text = "der er " + deviceCount +" Devices<br />";
            //foreach (TextBox tb in Serial_arr)
            //{
            //    MyLabel.Text += tb.Text + " :: ";
            //}
            //MyLabel.Text += "<br />";
            //foreach (TextBox tb in dynamicTextBoxes)
            //{
            //    MyLabel.Text += tb.Text + " :: ";
            //}
        
        }
        protected void btnAddTextBox_Click(object sender, EventArgs e)
        {
        }
        protected void btnRemoveTextBox_Click(object sender, EventArgs e)
        {
        }
    
    
    }
