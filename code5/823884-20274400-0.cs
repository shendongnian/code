    public partial class EquationSolver : Form
    {
        int x, y, z;
        //Button in the form named btnSolveForX
        private void btnSolveForX_Click(object sender, EventArgs e)
        {
            y = Int.Parse(txtY.Text);
            z = Int.Parse(txtZ.Text);
            x = z - y; // As x + y = z -> x = z -y
            txtX.Text = z.ToString();
            PrintResultInConsole();
        }
        //This function is to show that the x is still available
        //outside the scope of the functions as it is created
        //in the scope of class which means it is available anywhere
        //inside the class.
        private void PrintResultInConsole()
        {
            Console.WriteLine("Value of x is {0}",x);
        }
    }
