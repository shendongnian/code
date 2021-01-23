    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.UI.WebControls;
    using WebApp.RepeaterCheckboxList.TODODatasetTableAdapters;
    
    namespace WebApp.RepeaterCheckboxList
    {
        public partial class WebForm1 : System.Web.UI.Page
        {
            IEnumerable<TODODataset.TasksViewRow> view;
            IEnumerable<TODODataset.TasksViewRow> subview;
            protected void Page_Load(object sender, EventArgs e)
            {
                if (!IsPostBack)
                {
                    TasksViewTableAdapter adp = new TasksViewTableAdapter();
                    var dt = adp.GetData();
                    view = dt.AsEnumerable();
                    var names = (from x in view
                                 select new
                                 {
                                     Person = x.Name,
                                     ID = x.PersonID
                                 }).Distinct();
                    DataList1.DataSource = names;
                    DataList1.DataBind();
    
                }
            }
    
            protected void CheckBoxList1_DataBound(object sender, EventArgs e)
            {
                CheckBoxList theList = (CheckBoxList)sender;
                var person = ((DataListItem)theList.Parent).DataItem as dynamic;
                var name = person.Person;
                var id = person.ID;
    
                var vw = subview;
                for (int i = 0, j = vw.Count(); i < j; i++)
                {
                    var task = vw.ElementAt(i);
                    theList.Items[i].Selected = task.Completed;
                }
            }        
    
            protected IEnumerable<TODODataset.TasksViewRow> GetTasks(object data)
            {
                var vw = data as dynamic;
                return subview = (from x in view
                        where x.PersonID == vw.ID
                        select x);
    
            }
        }
    }
