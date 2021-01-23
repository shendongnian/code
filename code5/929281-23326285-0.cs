    private void ReloadForm()//Here is the new method I was talking about.
    {
     UserMonthlyPayLabel.ResetText();
      //this will reset the label I need for it to clear after change the model.
    }
     private void CalculateButton_Click(object sender, EventArgs e)
      {
       DetailsGroup.Visible = true;
       PaymentGroup.Visible = true;
       
       string[] ArrayModel ={"CAMERO", "IMPALA", "TAHOE", "SILVERADO", "MUSTANG", "TAURUS",
                             "EXPEDITION", "F150", "CAMERY", "COROLLA", "HIGHLANDER",
                             "TUNDRA", "CHALLENGER", "DART", "DURANGO", "RAM"};
       double[] ArrayLoan ={33809, 23300, 49601, 33383, 40585, 32500, 36245, 46905, 48050,
                            32560, 42580,47530, 27995,20150,39750,45620};
       double[] ArrayDuration = { 36, 48, 60, 72 };
       string Model = ModelBox.Text.ToUpper();
       double InterestRate = 0, TotalIntrst, MonthlyBill;
       string UsrModelVehicle = ModelBox.Text.ToUpper();
       double UsrScrInpt = Convert.ToDouble(CreditScoreBox.Text);
       ReloadForm();
     //Here is where I call it to reset the label. It works pretty good.
       {
        if (UsrScrInpt <= 450)
        {
         for (int x = 0; x < ArrayModel.Length; ++x)
         {
          if (Model == ArrayModel[x])
          {
           foreach (double Months in ArrayDuration)
           {
            ArrayModel[x] = Convert.ToString(ArrayLoan[x]);
            InterestRate = 0.12;
            TotalIntrst = InterestRate / 1200;
            MonthlyBill = ArrayLoan[x] * TotalIntrst / (1 - (Math.Pow(1 / (1 +TotalIntrst),
                          Months)));
            UserMonthlyPayLabel.Text += string.Format("{0:C2}\n", MonthlyBill);
            UserInterestLabel.Text = string.Format("{0:P2}", InterestRate);
            InterestLabel.Text = string.Format("Interest:");
            PayNumbersLabel.Text = string.Format("36\n48\n60\n72\n");
           }
          }
         }
        }
       }
      }
     }
    }
