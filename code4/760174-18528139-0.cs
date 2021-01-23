    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics;
    public class AmenLine : Control
    {
    
    	bool SzChInternaly;
    	public enum EDIR : int
    	{
    		Horizontal = 0,
    		Vertical = 1,
    		Slash = 2,
    		BKSlash = 3
    	}
    
    	public enum eStyle : int
    	{
    		rect = 0,
    		circ = 1
    	}
    
    	private eStyle _DrawStyle;
    	public eStyle DrawStyle {
    		get { return _DrawStyle; }
    		set {
    			_DrawStyle = value;
    			BuildMe(_Direc);
    		}
    	}
    
    	private EDIR _Direc = EDIR.Horizontal;
    	public EDIR Direction {
    		get { return _Direc; }
    		set {
    			if ((value == EDIR.Horizontal && _Direc == EDIR.Vertical) | (value == EDIR.Vertical && _Direc == EDIR.Horizontal)) {
    				SzChInternaly = true;
    				this.Size = new Size(this.Height, this.Width);
    			}
    			_Direc = value;
    			BuildMe(value);
    		}
    	}
    
    	private void BuildMe(EDIR BodyDir)
    	{
    		try {
    			SzChInternaly = true;
    			Drawing2D.GraphicsPath gr = new Drawing2D.GraphicsPath();
    			switch (BodyDir) {
    				case EDIR.Horizontal:
    					this.Size = new Size(this.Width, _BorderWidth + 10);
    					gr.AddRectangle(new Rectangle(0, (-_BorderWidth + this.Height) / 2, this.Width, _BorderWidth));
    					break;
    				case EDIR.Vertical:
    					this.Size = new Size(_BorderWidth + 10, this.Height);
    					gr.AddRectangle(new Rectangle((-_BorderWidth + this.Width) / 2, 0, _BorderWidth, this.Height));
    					break;
    				case EDIR.Slash:
    					try {
    						// CType(_BorderWidth * Height / Width, Integer)
    						for (i = 0; i <= Convert.ToInt32(Math.Pow(Math.Pow(Width, 2) + Math.Pow(Height, 2), 0.5)); i += _BorderWidth) {
    							switch (_DrawStyle) {
    								case eStyle.circ:
    									gr.AddPie(i, Convert.ToInt32(Height * i / Width), _BorderWidth, _BorderWidth, 0, 360);
    									break;
    								case eStyle.rect:
    									gr.AddRectangle(new Rectangle(i, Convert.ToInt32(Height * i / Width), _BorderWidth, _BorderWidth));
    									break;
    							}
    						}
    					} catch {
    					}
    					break;
    				case EDIR.BKSlash:
    					try {
    						// CType(_BorderWidth * Height / Width, Integer)
    						for (i = 0; i <= Convert.ToInt32(Math.Pow(Math.Pow(this.Height, 2) + Math.Pow(this.Width, 2), 0.5)); i += _BorderWidth) {
    							switch (_DrawStyle) {
    								case eStyle.circ:
    									gr.AddPie(Width - 1 - i, Convert.ToInt32(Height * i / Width), _BorderWidth, _BorderWidth, 0, 360);
    									break;
    								case eStyle.rect:
    									gr.AddRectangle(new Rectangle(Width - 1 - i, Convert.ToInt32(Height * i / Width), _BorderWidth, _BorderWidth));
    									break;
    							}
    						}
    					} catch {
    					}
    					break;
    			}
    			this.Region = new Region(gr);
    			SzChInternaly = false;
    		} catch {
    		}
    	}
    
    	private int _BorderWidth = 1;
    	public int BorderWidth {
    		get { return _BorderWidth; }
    		set {
    			_BorderWidth = value;
    			BuildMe(_Direc);
    		}
    	}
    
    	public AmenLine()
    	{
    		this.BackColor = Color.Black;
    		BuildMe(_Direc);
    	}
    
    	protected override void OnSizeChanged(System.EventArgs e)
    	{
    		base.OnSizeChanged(e);
    		if (SzChInternaly == false)
    			BuildMe(_Direc);
    	}
    }
