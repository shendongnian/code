    using System;
    using System.Drawing;
    using System.Windows.Forms;
    public class ThreePanel : Form {
      
      FlowLayoutPanel  leftFlow;
      FlowLayoutPanel  middleFlow;
      FlowLayoutPanel  rightFlow;
      
      public ThreePanel(){
        
        
        leftFlow = new FlowLayoutPanel() {
          BackColor = Color.Yellow
        };
        
        middleFlow = new FlowLayoutPanel() {
          BackColor = Color.LightGreen
        };
        
        rightFlow = new FlowLayoutPanel() {
          BackColor = Color.LightBlue
        };
        
        this.Controls.Add(rightFlow);
        this.Controls.Add(middleFlow);
        this.Controls.Add(leftFlow);
        
        this.Load += (s,e)=>Form1_Shown(s,e);
        this.Resize += (s,e)=>{ 
          int w=this.Width/3; 
          leftFlow.Width=middleFlow.Width
              =rightFlow.Width=w;
          leftFlow.Height=middleFlow.Height
              =rightFlow.Height=this.Height;
          leftFlow.Location=new Point(0,0);
          middleFlow.Location=new Point(w,0);
          rightFlow.Location=new Point(2*w,0);
        };
        
        this.Size = new Size(750,450);
        
      }
      
      private void Form1_Shown(object sender, EventArgs e)
      {
        Panel p = new Panel() {
          BorderStyle = BorderStyle.FixedSingle,
          Width = 200,
          Height = 100,
          BackColor = Color.Fuchsia,
        };
        
        Label label1 = new Label() {
          BorderStyle = BorderStyle.FixedSingle,
          Text = "Hello",
          Anchor = AnchorStyles.Top,
          Dock = DockStyle.Top
        };
        
        Label label2 = new Label() {
          BorderStyle = BorderStyle.FixedSingle,
          Text = "World!",
          Anchor = AnchorStyles.Bottom,
          Dock = DockStyle.Top
        };
          
        p.Controls.Add(label2);
        p.Controls.Add(label1);
        
        // add to the center most FlowLayoutPanel on Form1
        middleFlow.Controls.Add(p); 
      }
      
      public static void Main()
      {
        Application.Run(new ThreePanel());
      }
      
    }
