            public partial class Default : System.Web.UI.Page
            {
                Collection<double> numbers = new Collection<double>();
        
                protected void Page_Load(object sender, EventArgs e)
                {
        
                }
        
                protected void addButton_Click(object sender, EventArgs e)
                {
                    try
                    {
                        double number = Convert.ToDouble(numberTB.Text);
                        numbers.Add(number);
        
                    }
                    catch (FormatException) {
                    Console.WriteLine("Unable to convert '{0}' to a Double.", number);
                    }               
                    catch (OverflowException) {
                    Console.WriteLine("'{0}' is outside the range of a Double.", number);
                    }
        
                }
            }
