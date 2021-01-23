    public Form1()
    {
        // this is your constructor or form load event
        this.bindingSource1 = new BindingSource();
        this.bindingSource2 = new BindingSource();
    }
    public void BindData()
    {
        DataTable dt = this.FetchData(); 
       //implement FetchData as in your provided link excluding bindings and
       // return the created datatable
       //Bind bindingsources
       bindingSource1.DataSource = dt;
       bindingSource1.Filter = "Not IsSelected";
       bindingSource2.DataSource = dt;
       bindingSource2.Filter = "IsSelected";
       listWBox.DataSource = bindingSource1;
       // ... diplaymember etc.
       listbox2.DataSource = bindingSource2;
       //  ..displaymember etc.
