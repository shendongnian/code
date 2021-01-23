    using System;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.UI.WebControls;
    namespace Identity2_0
    {  
    public partial class Default : System.Web.UI.Page
    {
         protected void SearchBoxButton_Click(object sender, System.EventArgs e)
        {
            Parameter searchBox_par = new Parameter();
            string searchTxt = SearchBox.Text;
            string[] arrText = searchTxt.Split();
            searchBox_par.Name = "IDTextBox1";
            searchBox_par.Type = TypeCode.String; 
            for (int intCount = 0; intCount < arrText.Length; intCount++)
            {
                SqlDataSource1.SelectParameters.Clear(); 
                searchBox_par.DefaultValue = arrText[intCount];
                SqlDataSource1.SelectParameters.Add(searchBox_par);
            }
            
             GridView1.Visible = true;        }
    }
}
