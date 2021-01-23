    Form1:
    public event EventHandler<string> MenuItemChanged;
    //menu changed...
    if(this.MenuItemChanged != null)
        this.MenuItemChanged(this, menuitem)
    Form2:
    public Form2(Form1 otherForm)
    {
        InitializeComponent();
        _otherForm.MenuItemChange += //... handle your sql code
    }
