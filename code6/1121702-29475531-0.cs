    protected override void OnInit(EventArgs e)
    		{
    			base.OnInit(e);
             // check it here
             var p = GetPostBackControl(this.Page);
             if(p is Radcontrol.Controlx){ ... add it back again}
    }
