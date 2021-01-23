    //Paint event handler for your Panel
    private void panel1_Paint(object sender, PaintEventArgs e){ 
      if(panel1.BorderStyle == BorderStyle.FixedSingle){
         int thickness = 3;//it's up to you
         int halfThickness = thickness/2;
         using(Pen p = new Pen(Color.Black,thickness)){
           e.Graphics.DrawRectangle(p, new Rectangle(halfThickness,
                                                     halfThickness,
                                                     panel1.ClientSize.Width-thickness,
                                                     panel1.ClientSize.Height-thickness));
         }
      }
    }
