    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Data.SqlClient;
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            // You will need to put some validations before try to convert the values
            try
            {
                decimal priceRate = Convert.ToDecimal(this.txtPriceRate.Text);
                decimal newPrice = Convert.ToDecimal(this.txtNewPrice.Text);
                decimal priceLimit = Convert.ToDecimal(this.txtPriceLimit.Text);
                int wareMin = Convert.ToInt32(this.txtWareMin.Text);
                int wareMax = Convert.ToInt32(this.txtWareMax.Text);
                Update(newPrice * priceRate, priceLimit, wareMin, wareMax);
            }
            catch
            {
            }
        }
        public static void Update(decimal paramPrice, decimal paramPriceLimit, int paramWareMin, int paramWareMax)
        {
            string connectionString = System.Configuration.ConfigurationManager.AppSettings["connectionString"].ToString();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                String query = "UPDATE Ware SET Price = @paramPrice WHERE WareNr > @paramWareMin AND WareNr <= @paramWareMax AND Price >= @paramPriceLimit";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.Add("@paramPrice", "paramPrice");
                command.Parameters.Add("@paramPriceLimit", "paramPriceLimit");
                command.Parameters.Add("@paramWareMin", "paramWareMin");
                command.Parameters.Add("@paramWareMax", "paramWareMax");
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
