    using System.Threading;
    Thread t;
    private void btn_Xmas_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
    {
            ThreadStart del=new ThreadStart(dothis);
           t=new Thread(del);
    	t.Start();
    }
    
    private void btn_Xmas_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
    {
    	t.Abort();
    }
    public void dothis()
    {
    	while(true)
    	{
                  this.x=this.x+10;		
                                                                   this.crimsonModel.writeStringToAll("newX:"+x.ToString());
            }
    }
