    public partial class Form1 : Form
    {
        List<decimal> lstTotal = new List<decimal>();
        List<SalesPerson> lstSalesPerson = new List<SalesPerson>;
        
        public Form1()
        {
            InitializeComponent();
        }
        
        private void btnReadInSalesData_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "SalesNumbers.txt";
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK) //If and Open Dialog OK
            {
                StreamReader srFile = File.OpenText(openFileDialog1.FileName);
                decimal decTotal = 0;
                decimal tempSales =0;
                string tempName = "";
                
                while (!srFile.EndOfStream)
                {
                    string strline = srFile.ReadLine();
                    string[] strSplit = strline.Split('$');
                    // I'll seriously assume this happens only twice ...
                    foreach (string strSplittedOutput in strSplit)
                    {
                        if (decimal.TryParse(strSplittedOutput, out decTotal))
                        {
                            lstTotal.Add(decTotal);
                            lstTotalSales.Items.Add(strSplittedOutput);
                            tempSales = strSplittedOutput;
                        }
                        else //else than decimals add strings
                        {
                            lstNames.Items.Add(strSplittedOutput); //add the Sales men names to lstNames listbox
                            tempName = strSplittedOutput;
                        }
                    }
                    
                        // Adding this to our people list ...
                        lstSalesPerson.Add(new SalesPerson {Name=tempName,TotalSales=tempSales});
                        
                } //End of while
                srFile.Close(); //Close StreamReader
            }
            else
                MessageBox.Show("User Cancel Read File Operation."); // if the user cancel the read file operation show this messagebox
            
            // ... ??
        }
        
        // ...
    }
    
    
    public class SalesPerson {
        public string Name {get; set;}
        public decimal TotalSales {get; set;}
    }
