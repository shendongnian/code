    using System;
    using Microsoft.Uii.Csr;
    
    namespace Microsoft.Uii.QuickStarts
    {
    	public partial class QsHostedControl : HostedControl
    	{
    		public QsHostedControl()
    		{
    			InitializeComponent();
    		}
    
    		// Necessary constructor
    		public QsHostedControl(Guid appID, string appName, string initString)
    			: base(appID, appName, initString)
    		{
    			InitializeComponent();
    		}
    
    		private void QSHostedControl_Load(object sender, EventArgs e) {}
    
    		// This is the context change event handler.
    		public override void NotifyContextChange(Context context)
    		{
    			// This is the context change handler.
    
    			// Populating text fields from context information.
    			txtFirstName.Text = context["CustomerFirstName"];
    			txtLastName.Text = context["CustomerLastName"];
    			txtAddress.Text = context["Street"];
    			txtID.Text = context["CustomerID"];
    
    			// Hands control back over to the base class to notify next app of context change.
    			base.NotifyContextChange(context);
    		}
    
    		protected override void DoAction(RequestActionEventArgs args)
    		{
    			//Check the action name to see if it's something we know how to handle and perform appropriate work
    			switch (args.Action)
    			{
    				case "UpdateFirstName":
    					txtFirstName.Text = args.Data;
    					break;
    
    				case "UpdateLastName":
    					txtLastName.Text = args.Data;
    					break;                  
    			  
    			}
    		}
    
    		private void updateData_Click(object sender, EventArgs e)
    		{
    			// This is how you fire an action to other hosted applications. Your DoAction() code
    			// in your other application or application adapter will get called via this.
    			FireRequestAction(new RequestActionEventArgs("QSExternalApplication", "UpdateFirstName", txtFirstName.Text));
    			FireRequestAction(new RequestActionEventArgs("QSExternalApplication", "UpdateLastName", txtLastName.Text));
    
    			FireRequestAction(new RequestActionEventArgs("QSWebApplication", "UpdateFirstName", txtFirstName.Text));
    			FireRequestAction(new RequestActionEventArgs("QSWebApplication", "UpdateLastName", txtLastName.Text));
    			FireRequestAction(new RequestActionEventArgs("QSWebApplication", "UpdateAddress", txtAddress.Text));
    			FireRequestAction(new RequestActionEventArgs("QSWebApplication", "UpdateID", txtID.Text));
    		}
    
    		private void btnFireContextChange_Click(object sender, EventArgs e)
    		{
    			// Get the current context and create a new context object from it.
    			string temp = Context.GetContext();
    			Context updatedContext = new Context(temp);
    
    			// Update the new context with the changed information.
    			updatedContext["CustomerFirstName"] = txtFirstName.Text;
    			updatedContext["CustomerLastName"] = txtLastName.Text;
    			
    			// Notify everyone of this new context information
    			FireChangeContext(new ContextEventArgs(updatedContext));
    			// Tell self about this change
    			NotifyContextChange(updatedContext);
    
    		}
    	}
    }
