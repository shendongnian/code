    //Solution 1
    //Simply you have to add the ComboBox to the parent control first
    //before assigning its DataSource
    this.Controls.Add(cbo);   //<---- This goes first
    cbo.DataSource = DBCaller.GetListAsDataTable(fieldID); //<--- This goes after
    cbo.SelectedValue = value;
    //Solution 2
    //This is very strange and interesting, you can also add your ComboBox to 
    //the parent control after assigning its DataSource (as in your code).
    //But you have to ACCESS to the BindingContext property of your ComboBox
    //I would like to emphasize the ACCESS, you can perform any kind of access (Read and Write).
    //Here are some examples of such access:
    cbo.DataSource = DBCaller.GetListAsDataTable(fieldID);
    this.Controls.Add(cbo);  //<--- like in your code, this is placed here after the DataSource is assigned
    //here you can ACCESS the BindingContext
    var whatEver = cbo.BindingContext;//READ access
    if(cbo.BindingContext == null) Text = "????"; //READ access and of course it's not null
    cbo.BindingContext = new BindingContext();//WRITE access
    cbo.SelectedValue = value; //<---- This should be placed here after all.
