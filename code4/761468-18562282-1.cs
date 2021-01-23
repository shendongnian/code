    //in Form A
    private void btnOpenFromB_Click(sender,event)
    {
    FormB B =new FormB();
    if(B.ShowDialog()==DilogResult.Yes)
       //Call RefreshMethod of DG
    }
    //In Form B
     //in Constructor
    public FromB()
    {
       initilizeComponents();
       DialogResult=DialogResult.No;
    }
    //In Insert Button Click
    private void InserClick(sender,event)
    {
        if(Checking()==true)
         { 
            //Insert Operations
            DialogResult=DilogResult.Yes;
            this.Close();
          }
    }
