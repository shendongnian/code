    public partial class Forum : System.Web.UI.Page
    {
    
        protected void RadGrid1_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            List<Employee> list = new List<Employee>();
            list.Add(new Employee() { ID = 1, Name = "Name1" });
            list.Add(new Employee() { ID = 2, Name = "Name2" });
            list.Add(new Employee() { ID = 3, Name = "Name3" });
            list.Add(new Employee() { ID = 4, Name = "Name4" });
            list.Add(new Employee() { ID = 5, Name = "Name5" });
            RadGrid1.DataSource = list;
        }
    
    
        protected void RadGrid1_UpdateCommand(object sender, GridCommandEventArgs e)
        {
    
            GridEditableItem editedItem = e.Item as GridEditableItem;
    
            UserControl userControl = (UserControl)e.Item.FindControl(GridEditFormItem.EditFormUserControlID);
            string strName = (userControl.FindControl("TextBox1") as TextBox).Text; //Get usercontrol data
            string strName1 = (userControl as WebUserControl1).GetDataFromControls(); //Call the usercontrol Method
            //Perform your operation here
        }
    }
