    namespace Assigment9
    {
        public partial class Default : System.Web.UI.Page
        {
            double[] numbers = new double[5];
            int counter=0; // declare a global variable which will count the number of button clicks
            protected void Page_Load(object sender, EventArgs e)
            {
    
            }
    
            protected void addButton_Click(object sender, EventArgs e)
            {
                if(counter <5)                
                {
                 numbers[counter] = Convert.ToDouble(numberTB.Text);
                 counter ++;
                }
    
            }
        }
