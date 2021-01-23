    using Microsoft.VisualBasic;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics;
    using System.ComponentModel;
    using System.Windows.Forms;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Drawing.Imaging;
    
    public class transDataGridView : DataGridView
    {
        // VB Converted To C# And Code Edit : Murat Çakmak
        private bool _DGVHasTransparentBackground;
        [Category("Transparency"), Description("Select whether the control has a Transparent Background.")]
        public bool DGVHasTransparentBackground
        {
            get { return _DGVHasTransparentBackground; }
            set
            {
                _DGVHasTransparentBackground = value;
                if (_DGVHasTransparentBackground)
                {
                    this.SetTransparentProperties(true);
                }
                else
                {
                    this.SetTransparentProperties(false);
                }
            }
        }
    
        public transDataGridView()
        {
            DGVHasTransparentBackground = true;
        }
    
        private void SetTransparentProperties(bool SetAsTransparent)
        {
            if (SetAsTransparent)
            {
                base.DoubleBuffered = true;
                base.EnableHeadersVisualStyles = false;
                base.ColumnHeadersDefaultCellStyle.BackColor = Color.Transparent;
                base.RowHeadersDefaultCellStyle.BackColor = Color.Transparent;
                SetCellStyle(Color.Transparent);
            }
            else
            {
                base.DoubleBuffered = false;
                base.EnableHeadersVisualStyles = true;
                base.ColumnHeadersDefaultCellStyle.BackColor = SystemColors.Control;
                base.RowHeadersDefaultCellStyle.BackColor = SystemColors.Control;
                SetCellStyle(Color.White);
            }
        }
    
        protected override void PaintBackground(System.Drawing.Graphics graphics, System.Drawing.Rectangle clipBounds, System.Drawing.Rectangle gridBounds)
        {
            base.PaintBackground(graphics, clipBounds, gridBounds);
    
            if (_DGVHasTransparentBackground)
            {
                //  DataGridView Transparent !
                SolidBrush myBrush = new SolidBrush(base.Parent.BackColor); // (Form1 BackColor) veya bir resme boyanabilir.
                Region rectDest = new Region(new Rectangle(0, 0, base.Width, base.Height));
                graphics.FillRegion(myBrush, rectDest);
    
               
            }
        }
    
        protected override void OnColumnAdded(System.Windows.Forms.DataGridViewColumnEventArgs e)
        {
            base.OnColumnAdded(e);
            if (_DGVHasTransparentBackground)
            {
                SetCellStyle(Color.Transparent);
            }
        }
    
        private void SetCellStyle(Color cellColour)
        {
            foreach (DataGridViewColumn col in base.Columns)
            {
                col.DefaultCellStyle.BackColor = cellColour;
                col.DefaultCellStyle.SelectionBackColor = cellColour; // selection cell color example Color.Red;
            }
        }
    
    }
