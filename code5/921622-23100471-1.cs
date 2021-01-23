       private void Form1_Load(object sender, EventArgs e)
        {
            string[] myfile = File.ReadAllLines(@"C:\temp\customerinfo.csv");
            var myQuery = from mylines in myfile
                          let myfield = mylines.Split(',')
                          let CustomerID = myfield[0]
                          let CustomerFirstName = myfield[1]
                          let CustomerLastName = myfield[2]
                          orderby CustomerID, CustomerLastName, CustomerFirstName
                          select new { 
                          CustomerID, CustomerFirstName, CustomerLastName
                          };
            foreach (var customerinfo in myQuery) { cmbCustomer.Items.Add(customerinfo.CustomerID + " " + customerinfo.CustomerFirstName + " " + customerinfo.CustomerLastName); }
            
        }
        private void getCustomerFirstandID(out string customerfirst, out string idd)
        {
            string[] tempp = cmbCustomer.SelectedItem.ToString().Split(' ');
            customerfirst = tempp[1];
            idd = tempp[0];       
        }
        private void getCustomerInfo(string StatedID)
        {
            string[] myfile = File.ReadAllLines(@"C:\temp\customerinfo.csv");
            var myQuery = from mylines in myfile
                          let myfield = mylines.Split(',')
                          let CustomerID = myfield[0]
                          let CustomerFirstName = myfield[1]
                          let CustomerLastName = myfield[2]
                          where CustomerID == StatedID
                          select new
                          {
                              CustomerID,
                              CustomerFirstName,
                              CustomerLastName
                          };
        
        
        }
        private void getPackagePriceInfo(DateTime date, ref double CostofAdults, ref double CostofSingle, ref byte NumberofDaysShown)
        {
            string[] myGivenFile = File.ReadAllLines(@"C:\temp\PackagePrice.csv");
            var myPackageTransaction = from myLinesGiven in myGivenFile
                                       let myFieldShown = myLinesGiven.Split(',')
                                       let NumberofDays = myFieldShown[0]
                                       let StartDate = DateTime.Parse(myFieldShown[1])
                                       let TwinAdult = myFieldShown[2]
                                       let SingleAdult = myFieldShown[3]
                                       where StartDate == date
                                       select new { 
                                       NumberofDays, StartDate, TwinAdult, SingleAdult
                                       
                                       };
            foreach (var Package in myPackageTransaction) {
                CostofSingle = double.Parse(Package.SingleAdult);
                CostofAdults = double.Parse(Package.TwinAdult);
                NumberofDaysShown = byte.Parse(Package.NumberofDays);
                date = Package.StartDate;
                break;
            }
        
        
        }
        private void cmbCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            string customerfirstvariable = "";
            string iddvariable = "";
            getCustomerFirstandID(out customerfirstvariable, out iddvariable);
            getCustomerInfo(iddvariable);
            string format1 = "{0,55}{1,5}";
            string format2 = "{0,-5:d}{1,15:d}{2,20:c}{3,20:c}";
            string format3 = "{0,25}{1,19:c}{2,20:c}";
            string format4 = "{0,-15}{1,72:c}";
            string[] myGivenFile1 = File.ReadAllLines(@"C:\temp\holidaytrans.csv");
            var myHolidayTransaction = from myLinesGiven1 in myGivenFile1
                                       let myFieldShown = myLinesGiven1.Split(',')
                                       let CustomerGivenID = myFieldShown[0]
                                       let PackageStartDate = DateTime.Parse(myFieldShown[1])
                                       let NumberofAdults = myFieldShown[2]
                                       let NumberofKids = myFieldShown[3]
                                       where CustomerGivenID == iddvariable
                                       orderby PackageStartDate
                                       select new
                                       {
                                          CustomerGivenID, PackageStartDate, NumberofAdults, NumberofKids
                                       };
                lstInvoice.Items.Clear();
         //   foreach (var transactionfound in myHolidayTransaction) {
              
                
        //set up all variables used or to be used.
                 string EndofDays = "";
                DateTime daybegin;
                DateTime startthedate;
                DateTime datebeginning = DateTime.Now;
                string idgiven = "";
                double AdultCost = 0;
                byte DaysUsed = 0;
                double adultpricing = 0;
                double KidsPricing = 0;
                double KidsCost = 3300;
                double subtotal = 0;
                double totalamt = 0;
                double subtotal1 = 0;
                double total1 = 0;
                double total = 0;
                double CostSingle = 0;
                byte numberAdults = 0;
                double adultgiven = 0;
            int xyz = 0;
                foreach (var Transaction in myHolidayTransaction)
                {
                    idgiven = Transaction.CustomerGivenID;
                    lstInvoice.Items.Add("Purchase Date     EndDate          Adult Price          Kid Price");
                    datebeginning = Transaction.PackageStartDate;
                    xyz = datebeginning.Year;
                    break;
                
                }
            
                foreach (var Transaction in myHolidayTransaction)
                {
                    if (Transaction.PackageStartDate.Year == xyz) {
                        getPackagePriceInfo(Transaction.PackageStartDate,ref AdultCost,  ref  CostSingle, ref DaysUsed);
                        KidsPricing = KidsCost * byte.Parse(Transaction.NumberofKids);
                        numberAdults = byte.Parse(Transaction.NumberofAdults);
                        if(numberAdults == 2)
                            adultpricing = AdultCost*2;
                        else
                            adultpricing = CostSingle;
                        
                     
                        subtotal += KidsPricing;
                        subtotal1 += adultpricing;
                        total += KidsPricing;
                        total1 += adultpricing;
                        daybegin = Transaction.PackageStartDate;
                        startthedate = daybegin.AddDays(DaysUsed);
                        EndofDays = startthedate.ToString("d");
                        lstInvoice.Items.Add(string.Format(format2, startthedate, EndofDays, adultpricing, KidsPricing));}
                        else
                        {
                        lstInvoice.Items.Add(string.Format(format3, "Subtotal Amount", subtotal1, subtotal));
                        lstInvoice.Items.Add(" ");
                        getPackagePriceInfo(Transaction.PackageStartDate, ref AdultCost, ref  CostSingle, ref DaysUsed);
                        KidsPricing = KidsCost * byte.Parse(Transaction.NumberofKids);
                        numberAdults = byte.Parse(Transaction.NumberofAdults);
                        if (numberAdults == 2)
                            adultpricing = AdultCost * 2;
                        else
                            adultpricing = CostSingle;
                        subtotal = KidsPricing;
                        subtotal1 = adultpricing;
                        total += KidsPricing;
                        total1 += adultpricing;
                        daybegin =Transaction.PackageStartDate;
                        startthedate = daybegin.AddDays(DaysUsed);
                        EndofDays = startthedate.ToString("d");
                        lstInvoice.Items.Add(string.Format(format2, startthedate, EndofDays, adultpricing, KidsPricing));
                        idgiven = Transaction.CustomerGivenID;
                        xyz = Transaction.PackageStartDate.Year;
             
                 }}
                    
       if (idgiven == "")
                    {
                    lstInvoice.Items.Clear();
                    lstInvoice.Items.Add(string.Format(format1, "Sorry no Transaction Found For" + " ", customerfirstvariable));
                    } 
       else
                    lstInvoice.Items.Add(" "); 
                    lstInvoice.Items.Add(string.Format(format3, "Subtotal Amount", subtotal1, subtotal));
                    lstInvoice.Items.Add(" ");
                    lstInvoice.Items.Add(string.Format(format3, "Total Amount", total1, total));
                    
            } 
                    }
                    
                
                
                }
            
            
       
        
