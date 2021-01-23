     800.00 (base) 
    + 46.25 (5% bonus when over 80% base) 
    + 92.50 (10% commission on 925 sales)
    =======
     938.75
    -150.20 (16% FICA)
    =======
     788.55 Net pay before union dues
    -  5.25 (union) 
    =======
     783.30
    private void btnDisplay_Click(object sender, EventArgs e)
    {
       string EmploymentStatus = Convert.ToString(txtES.Text).ToLower();
       string UnionStatus = Convert.ToString(txtMS.Text).ToLower();
       double TotalSales = Convert.ToDouble(txtSales.Text) * 9.25;
       double Years = Convert.ToDouble(txtYears.Text);         
       double uniondues = 0;
       double FICA = 0;
       double bonus = 0;
       double WPay = 0;
       double TotalComission = 0;
    
    
       if (EmploymentStatus == "full")
       {
          WPay = 800.00;
          // since already in full-time status check, compute bonus here now.
          // based on 80% of base pay
          if (TotalSales > WPay * .80)
             bonus = TotalSales * .05;
       }
       else if (EmploymentStatus == "part")
          WPay = 200.00;
       else
          MessageBox.Show("Error, please enter either FULL or PART");
    
       // Only if qualified full/part time status
       if( WPay > 0 )
       {
          if (UnionStatus == "member")
             uniondues = 5.25;
          else if (UnionStatus == "non-member")
             uniondues = 0;
          else
             MessageBox.Show("Error, please enter either MEMBER or NON-MEMBER");
             
          if (Years >= 10)
             TotalComission = TotalSales * .10;
          else if (Years < 10)
             TotalComission = TotalSales * .05;
          else
             MessageBox.Show("Error, please enter a valid number");
    
    
          // NOW, build out the total pay before computing FICA
          WPay = WPay + bonus + TotalComission;
          
          // NOW Compute FICA
          FICA = WPay * .16;
          
          // and remove FICA and Union dues from gross pay to get net pay
          WPay = WPay - FICA - uniondues;
       }
    
       lblqWPay.Text = "The weekly pay for the employee is: " + (WPay.ToString("C"));
       lblqTS.Text = "The total sales for this employee is: " + (TotalSales.ToString("C"));
       lblqCom.Text = "The comission for this employee is: " + (TotalComission.ToString("C"));
       lblqBonus.Text = "The bonus for this employee is: " + (bonus.ToString("C"));
    }
