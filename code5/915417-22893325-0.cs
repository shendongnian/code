    using System.Globalization;
    using IdentitySample.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.Owin;
    using Microsoft.Owin.Security;
    using System;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using System.Web;
    using System.Web.Mvc;
    using System.Data.SqlClient;
    using System.Collections;
    using System.Web.UI.WebControls.Parameter;
    using System.Data;
    namespace Identity2_0
    {
   
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        
        protected void SearchBoxButton_Click(object sender, System.EventArgs e)
        {
            Parameter searchBox_par = new Parameter(); 
            string searchTxt = SearchBox.Text;
            string[] arrText = searchTxt.Split(); 
           
            SqlDataSource1.SelectParameters.Clear();
            
            for (int intCount = 0; intCount < arrText.Length; intCount++)
            {
                searchBox_par.Name = "IDTextBox1";
                searchBox_par.Type = TypeCode.String;
                searchBox_par.DefaultValue = arrText[intCount];
                SqlDataSource1.SelectParameters.Add(searchBox_par);
            }
        }
        
    }
}
