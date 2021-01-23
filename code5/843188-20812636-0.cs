    using Microsoft.VisualBasic;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics;
    public class FlatCombo : ComboBox
    {
    
    	private Brush BorderBrush = new SolidBrush(SystemColors.Window);
    	private Brush ArrowBrush = new SolidBrush(SystemColors.ControlText);
    	private Brush DropButtonBrush = new SolidBrush(SystemColors.Control);
    
    	private Color _ButtonColor = SystemColors.Control;
    	public Color ButtonColor {
    		get { return _ButtonColor; }
    		set {
    			_ButtonColor = value;
    			DropButtonBrush = new SolidBrush(this.ButtonColor);
    			this.Invalidate();
    		}
    	}
    
    	protected override void WndProc(ref Message m)
    	{
    		base.WndProc(m);
    
    		switch (m.Msg) {
    			case 0xf:
    				//Paint the background. Only the borders
    				//will show up because the edit
    				//box will be overlayed
    				Graphics g = this.CreateGraphics;
    				Pen p = new Pen(Color.White, 2);
    				g.FillRectangle(BorderBrush, this.ClientRectangle);
    
    				//Draw the background of the dropdown button
    				Rectangle rect = new Rectangle(this.Width - 15, 3, 12, this.Height - 6);
    				g.FillRectangle(DropButtonBrush, rect);
    
    				//Create the path for the arrow
    				Drawing2D.GraphicsPath pth = new Drawing2D.GraphicsPath();
    				PointF TopLeft = new PointF(this.Width - 13, (this.Height - 5) / 2);
    				PointF TopRight = new PointF(this.Width - 6, (this.Height - 5) / 2);
    				PointF Bottom = new PointF(this.Width - 9, (this.Height + 2) / 2);
    				pth.AddLine(TopLeft, TopRight);
    				pth.AddLine(TopRight, Bottom);
    
    				g.SmoothingMode = Drawing2D.SmoothingMode.HighQuality;
    
    				//Determine the arrow's color.
    				if (this.DroppedDown) {
    					ArrowBrush = new SolidBrush(SystemColors.HighlightText);
    				} else {
    					ArrowBrush = new SolidBrush(SystemColors.ControlText);
    				}
    
    				//Draw the arrow
    				g.FillPath(ArrowBrush, pth);
    
    				break;
    			default:
    				break; // TODO: might not be correct. Was : Exit Select
    
    				break;
    		}
    	}
    
    	//Override mouse and focus events to draw
    	//proper borders. Basically, set the color and Invalidate(),
    	//In general, Invalidate causes a control to redraw itself.
    	#region "Mouse and focus Overrides"
    	protected override void OnMouseEnter(System.EventArgs e)
    	{
    		base.OnMouseEnter(e);
    		BorderBrush = new SolidBrush(SystemColors.Highlight);
    		this.Invalidate();
    	}
    
    	protected override void OnMouseLeave(System.EventArgs e)
    	{
    		base.OnMouseLeave(e);
    		if (this.Focused)
    			return;
    		BorderBrush = new SolidBrush(SystemColors.Window);
    		this.Invalidate();
    	}
    
    	protected override void OnLostFocus(System.EventArgs e)
    	{
    		base.OnLostFocus(e);
    		BorderBrush = new SolidBrush(SystemColors.Window);
    		this.Invalidate();
    	}
    
    	protected override void OnGotFocus(System.EventArgs e)
    	{
    		base.OnGotFocus(e);
    		BorderBrush = new SolidBrush(SystemColors.Highlight);
    		this.Invalidate();
    	}
    
    	protected override void OnMouseHover(System.EventArgs e)
    	{
    		base.OnMouseHover(e);
    		BorderBrush = new SolidBrush(SystemColors.Highlight);
    		this.Invalidate();
    	}
    	#endregion
    }
