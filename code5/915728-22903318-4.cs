    this.form.Resize += // some handler1
    
    //in hadler1
    {
       this.form.Paint += // Your new paint handler2
    }
    //in handler2
    {
       Rectangle r = new Rectangle(0,0,this.ClientRectangle.Width-1,this.ClientRectangle.Height-1);
       e.Graphics.DrawRectangle(new Pen(Color.Gray, 1.0f), r);
    }
