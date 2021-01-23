    private string _yourcomboboxitem=string.Empty; // Here i make a private field to store your data 
    public string Yourcomboboxitem // make public property 
    {
        get{return _comboboxitem;}
        set{ comboboxitem = value;}
    }
    private void frmAdd_Load(object sender, EventArgs e)
     {
            DataClasses1DataContext db=new DataClasses1DataContext();
            var q=from c in db.Groups
                  select c.GroupName;
            cbGroup.DataSource = q;
           cbGroup.SelectedItem = this.Yourcomboboxitem; // when form load your comboxbox will set item which you assign value to your property
     }
