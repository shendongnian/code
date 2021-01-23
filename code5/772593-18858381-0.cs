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
            int index = 0;
    
            public Form1()
            {
                InitializeComponent();
    
                this.theListBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
                this.theListBox.DrawItem += new System.Windows.Forms.DrawItemEventHandler( this.theListBox_DrawItem );
    
                this.theTimer.Start();
            }
    
            void theTimer_Tick( object sender, EventArgs e )
            {
                this.theListBox.SelectedIndex = index;
    
                if ( ++index >= this.theListBox.Items.Count )
                {
                    index = 0;
                }
            }
    
            void theListBox_DrawItem( object sender, DrawItemEventArgs e )
            {
                e.Graphics.FillRectangle( SystemBrushes.Window, e.Bounds );
    
                if ( e.Index >= 0 )
                {
                    e.Graphics.DrawString( this.theListBox.Items[ e.Index ].ToString(), this.theListBox.Font, SystemBrushes.WindowText, e.Bounds );
                }
    
                // Comment out the following line if you don't want
                // the see the focus rectangle around the currently
                // selected item.
                //
    
                e.DrawFocusRectangle();
    
            }
        }
    }
