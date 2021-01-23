	#region
	using System;
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.Diagnostics;
	using System.Drawing;
	using System.Linq;
	using System.Windows.Forms;
	using SkyAnimation.Properties;
	#endregion
	namespace SkyAnimation
	{
		/// <summary>
		/// </summary>
		public partial class NoFlickerControl : UserControl
		{
			#region Fields
			private readonly List<RectangleF> _tiles = new List<RectangleF>();
			private DateTime _lastTick;
			private Bitmap _offscreenBitmap;
			private Graphics _offscreenGraphics;
			private Bitmap _skyBitmap;
			#endregion
			#region Constructor
			public NoFlickerControl()
			{
				// set defaults first
				DesiredFps = Defaults.DesiredFps;
				NumberOfTiles = Defaults.NumberOfTiles;
				Speed = Defaults.Speed;
				InitializeComponent();
				if (DesignMode)
				{
					return;
				}
				_lastTick = DateTime.Now;
				timer1.Tick += Timer1OnTick;
				timer1.Interval = 1000/DesiredFps; // How frequenty do we want to recalc positions
				timer1.Enabled = true;
			}
			#endregion
			#region Properties
			/// <summary>
			///     This controls how often we recalculate object positions
			/// </summary>
			/// <remarks>
			///     This can be independant of rendering FPS
			/// </remarks>
			/// <value>
			///     The frames per second.
			/// </value>
			[DefaultValue(Defaults.DesiredFps)]
			public int DesiredFps { get; set; }
			[DefaultValue(Defaults.NumberOfTiles)]
			public int NumberOfTiles { get; set; }
			/// <summary>
			///     Gets or sets the sky to draw.
			/// </summary>
			/// <value>
			///     The sky.
			/// </value>
			[Browsable(false)]
			public Bitmap Sky { get; set; }
			/// <summary>
			///     Gets or sets the speed in pixels/second.
			/// </summary>
			/// <value>
			///     The speed.
			/// </value>
			[DefaultValue(Defaults.Speed)]
			public float Speed { get; set; }
			#endregion
			#region Methods
			private void HandleResize()
			{
				// the control has resized, time to recreate our offscreen bitmap
				// and graphics context
				if (Width == 0
					|| Height == 0)
				{
					// nothing to do here
				}
				_offscreenBitmap = new Bitmap(Width, Height);
				_offscreenGraphics = Graphics.FromImage(_offscreenBitmap);
			}
			private void NoFlickerControl_Load(object sender, EventArgs e)
			{
				SkyInTheWindow();
				HandleResize();
			}
			private void NoFlickerControl_Resize(object sender, EventArgs e)
			{
				HandleResize();
			}
			/// <summary>
			///     Handles the SizeChanged event of the NoFlickerControl control.
			/// </summary>
			/// <param name="sender">The source of the event.</param>
			/// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
			private void NoFlickerControl_SizeChanged(object sender, EventArgs e)
			{
				HandleResize();
			}
			/// <summary>
			///     Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
			/// </summary>
			/// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data. </param>
			protected override void OnPaint(PaintEventArgs e)
			{
				var g = e.Graphics;
				var rc = e.ClipRectangle;
				if (_offscreenBitmap == null
					|| _offscreenGraphics == null)
				{
					g.FillRectangle(Brushes.Gray, rc);
					return;
				}
				DrawOffscreen(_offscreenGraphics, ClientRectangle);
				g.DrawImageUnscaled(_offscreenBitmap, 0, 0);
			
			}
			private void DrawOffscreen(Graphics g, RectangleF bounds)
			{
				// We don't care about erasing the background because we're
				// drawing over it anyway
				//g.FillRectangle(Brushes.White, bounds);
				//g.SetClip(bounds);
		
				foreach (var tile in _tiles)
				{
					if (!(bounds.Contains(tile) || bounds.IntersectsWith(tile)))
					{
						continue;
					}
					g.DrawImageUnscaled(_skyBitmap, new Point((int) tile.Left, (int) tile.Top));
				}
			}
			/// <summary>
			///     Paints the background of the control.
			/// </summary>
			/// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
			protected override void OnPaintBackground(PaintEventArgs e)
			{
				// NOP
				// We don't care painting the background here because
				// 1. we want to do it offscreen
				// 2. the background is the picture anyway
			}
			/// <summary>
			///     Responsible for updating/translating game objects, not drawing
			/// </summary>
			/// <param name="totalMillisecondsSinceLastUpdate">The total milliseconds since last update.</param>
			/// <remarks>
			///     It is worth noting that OnUpdate could be called more times per
			///     second than OnPaint.  This is fine.  It's generally a sign that
			///     rendering is just taking longer but we are able to compensate by
			///     tracking time since last update
			/// </remarks>
			private void OnUpdate(double totalMillisecondsSinceLastUpdate)
			{
				// Remember that we measure speed in pixels per second, hence the
				// totalMillisecondsSinceLastUpdate
				// This allows us to have smooth animations and to compensate when
				// rendering takes longer for certain frames
				for (int i = 0; i < _tiles.Count; i++)
				{
					var tile = _tiles[i];
					tile.Offset((float)(-Speed * totalMillisecondsSinceLastUpdate / 1000f), 0);
					_tiles[i] = tile;
				}
			}
			private void SkyInTheWindow()
			{
				_tiles.Clear();
                // here I load the bitmap from my embedded resource
                // but you easily could just do a new Bitmap ("C:/MyPath/Sky.jpg");
				_skyBitmap = Resources.sky400x400;
				var bounds = new Rectangle(0, 0, _skyBitmap.Width, _skyBitmap.Height);
				for (var i = 0; i < NumberOfTiles; i++)
				{
					// Loading sky into the window
					_tiles.Add(bounds);
					bounds.Offset(bounds.Width, 0);
				}
			}
			private void Timer1OnTick(object sender, EventArgs eventArgs)
			{
				if (DesignMode)
				{
					return;
				}
				var ellapsed = DateTime.Now - _lastTick;
				OnUpdate(ellapsed.TotalMilliseconds);
				_lastTick = DateTime.Now;
				// queue cause a repaint
				// It's important to realise that repaints are queued and fused
				// together if the message pump gets busy
				// In other words, there may not be a 1:1 of OnUpdate : OnPaint
				Invalidate(Bounds);
			}
			#endregion
		}
		public static class Defaults
		{
			public const int DesiredFps = 30;
			public const int NumberOfTiles = 100;
			public const float Speed = 300f;
		}
	}
