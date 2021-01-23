    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    namespace WindowsFormsApplication1
    {
       class Node:Label
       {
          public Node(int x, int y)
            {
                this.Top = y;
                this.Left = x;
            }
            public void updatePos(int x, int y)
            {
                this.Top += y;
                this.Left += x;
            }
       }
    }
