    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    
    public partial class CheckboxGrid : System.Web.UI.Page
    {
    	protected void Page_Load(object sender, EventArgs e)
    	{
    		if (!IsPostBack)
    		{
    			//Get data and bind the grid
    			gvResourceUsers.DataSource = GetData();
    			gvResourceUsers.DataBind();
    		}
    	}
    
    	protected void gvResourceUsers_OnRowDataBound(Object sender, GridViewRowEventArgs e)
    	{
    		//As each row is data-bound, set the checkbox state.
    		if (e.Row.RowType == DataControlRowType.DataRow)
    		{
    			var resourceUser = e.Row.DataItem as ResourceUser;
    			var cbxOwner = e.Row.FindControl("cbxOwner") as CheckBox;
    			var cbxAdministrator = e.Row.FindControl("cbxAdministrator") as CheckBox;
    
    			cbxOwner.Checked = resourceUser.Owner;
    			cbxAdministrator.Checked = resourceUser.Administrator;
    		}
    	}
    
    	protected void btnSubmit_Click(Object sender, EventArgs e)
    	{
    		var resourceUsers = new List<ResourceUser>();
    
    		//Iterate the gridview rows and populate the collection from the postback data.
    		foreach (GridViewRow row in gvResourceUsers.Rows)
    		{
    			resourceUsers.Add(
    				new ResourceUser
    				{
    					Name = row.Cells[0].Text,
    					Surname = row.Cells[1].Text,
    					Owner = ((CheckBox)row.Cells[2].FindControl("cbxOwner")).Checked,
    					Administrator = ((CheckBox)row.Cells[3].FindControl("cbxAdministrator")).Checked
    				});
    		}
    	}
    
    	private IEnumerable<ResourceUser> GetData()
    	{
    		//We just create some data for demo purposes. Here you would normally populate the collection from your database.
    		var resourceUsers = new List<ResourceUser>
    			{
    				new ResourceUser{Name = "Bob", Surname = "Taylor", Owner = true, Administrator = true },
    				new ResourceUser{Name = "Ann",  Surname = "Carter", Owner = false, Administrator = true },
    				new ResourceUser{Name = "Toni",  Surname = "Wong", Owner = false, Administrator = false}
    			};
    
    		return resourceUsers;
    	}
    
    	//A data view model to contain our view data for the grid
    	private class ResourceUser
    	{
    		public String Name { get; set; }
    
    		public String Surname { get; set; }
    
    		public Boolean Owner { get; set; }
    
    		public Boolean Administrator { get; set; }
    	}
    }
