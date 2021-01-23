        using System;
        using System.Collections.Generic;
        using System.ComponentModel;
        using System.Data;
        using System.Drawing;
        using System.Linq;
        using System.Text;
        using System.Windows.Forms;
    
        namespace WindowsFormsApplication1
        {
            public partial class Form1 : Form
            {
                Bitmap buffer;  //used to draw the lines and txt on first then make the Forms     Background image = buffer
                public Form1()
                {
                    InitializeComponent();
                    //set the buffer to the same size as the form
                    buffer = new Bitmap(Width, Height);
      
                    //calls the method below
                    DrawLines(100,50,5,Graphics.FromImage(buffer));
    
                    //sets the background image to = buffer
                BackgroundImage = buffer; 
               
            }
    
            public void DrawLines(int startX, int startY, int segments, Graphics g)
            {
                // this needs to be looked at since it pushes the lines off the screen
                //perhaps you need to indicate a total line length then use it here instead of this.Height
                
                //int TotalLength=500;
                //int segmentLength = TotalLength / segments; 
    
                int segmentLength=this.Height/segments; 
                
                //I have created a array containing 5 Colors, this way I can reference them from within the For Loop below
                //You can use whichever colors you wish
                
                Color[] Colors = new Color[] { Color.Black, Color.Red,Color.Orange,Color.Yellow,Color.Green };
    
                //Loop through each of the segments
    
                for (int y = 0; y < segments; y++)
                {
                    //the using statements ensures your new p is disposed of properly when you are finished.  You could also use
                    // Pens.Red, or Pens.Black, which do not need to be disposed of instead of creating a new one
                    using (Pen p= new Pen(Colors[y]))
                        g.DrawLine(p,new Point(startX,startY+(y*segmentLength)),new Point(startX,startY+((y+1)*segmentLength)));
                    //same thing for Pens also applies to Brush...  Brushes.Red, Brushes.Black etc...
                    using (Brush b = new SolidBrush(Colors[y]))
                        g.DrawString(Colors[y].Name, Font, b, new Point(startX + 5, startY + (y * segmentLength) + (segmentLength / 2)));
                }
            }
        }
    }
