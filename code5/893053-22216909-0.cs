    private Painter _painter;
    private void Main_Load(object sender, EventArgs e)
    {   
        //...    
        _painter = new Painter();
        _painter.Paint(this);
    }
    class Painter
    {
       public void Paint(Form main)
       {   
    //... 
        main.Controls.Add(label1);    
        main.Controls.Add(txtbx1);
    //...
        }
    }
