    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI.WebControls;
    using System.Web.UI;
    using System.Data;
    public class AddTemplateToDetailsView : ITemplate
    {
       private ListItemType m_ListItemType;
        
        public AddTemplateToDetailsView(ListItemType _listItemType)
        {
           m_ListItemType = _listItemType;
        }
        public void InstantiateIn(System.Web.UI.Control container)
        {
            if (m_ListItemType == ListItemType.Item)
            {
                Label lblID = new Label();
                lblID.DataBinding += new EventHandler(lblID_DataBinding);
                container.Controls.Add(lblID);    
            }    
        }    
        void lblID_DataBinding(object sender, EventArgs e)
        {    
            Label lblID = (Label)sender;
            string str = lblID.NamingContainer.ToString();
            DetailsView container = (DetailsView)lblID.NamingContainer;
            lblID.Text = ((DataRowView)container.DataItem)["CustomerID"].ToString();
        }
    
    }
