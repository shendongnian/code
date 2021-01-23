    protected void Af_FilterButtonClicked(object sender, EventArgs args)
    {    
       if(!string.isNullOrWhiteSpace(jobFilter.SelectedCountry))
       {
         var data= YourDataSource.Where(c=> c.YourCountryField == jobFiler.SelectedCountry).ToList();
         YourGrid.DataSource= data;
         YourGrid.DataBind(); // or Rebind()
       }
    }
