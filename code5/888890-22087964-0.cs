     protected void Page_Load(object sender, EventArgs e)
            {
                if(!IsPostBack)
                {
                GridView3.DataBind();
                }
              //  lblSelectedDate.Text = AJAXDatePickerControl1.selectedDate.ToShortDateString();
            }
