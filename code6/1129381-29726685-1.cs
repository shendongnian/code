    protected void UpdateDetails_Click(object sender, EventArgs e)
        {
            if(IsPostBack)
            {
                 Person_T _person = new Person_T(){
                      FirstName = TextBoxFN.Text,
                      LastName = TextBoxLN.Text                      
                 };
                
                QS = Request.QueryString["ReqID"];
                inte = Convert.ToInt32(QS);
                OBJECTCONT.UpdateEmployeeDetails(inte, _person);    
            }    
        }
