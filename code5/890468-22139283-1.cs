	using System;
	using System.Collections.Generic;
	using System.Drawing;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;
	using System.Windows.Forms;
	namespace LicensePlate
	{
		/// <summary>
		/// The GlowButton class
		/// </summary>
		public class GlowButton : Button
		{
			#region Fields
			Timer timer;
			private int alpha;
			Color color;
			#endregion
			#region Events
			#endregion
			#region Constructor
			/// <summary>
			/// Creates a new instance of the GlowButton class.
			/// </summary>
			public GlowButton()
			{
				timer = new Timer();
				timer.Interval = 100;
				timer.Tick += timer_Tick;
			}
			#endregion
			#region Methods
			/// <summary>
			/// Only used if you need something else to trigger the glow process
			/// </summary>
			private void ShowGlow()
			{
				timer.Start();
			}
			/// <summary>
			/// Start the timer and reset glow if the mouse enters
			/// </summary>
			/// <param name="e"></param>
			protected override void OnMouseEnter(EventArgs e)
			{
				timer.Start();
				alpha = 0;
			}
			
			/// <summary>
			/// Reset the glow when the mouse leaves
			/// </summary>
			/// <param name="e"></param>
			protected override void OnMouseLeave(EventArgs e)
			{
				timer.Stop();
				alpha = 0;
				color = BackColor;
				Invalidate();
			}
			
			/// <summary>
			/// Override paint so that it uses your glow regardless of when it is instructed to draw
			/// </summary>
			/// <param name="pevent"></param>
			protected override void OnPaint(PaintEventArgs pevent)
			{
				base.OnPaint(pevent);
				if (alpha > 0)
				{
					using (Brush b = new SolidBrush(color))
					{
						pevent.Graphics.FillRectangle(b, this.ClientRectangle);
					}
				}
				
				//base.OnPaint(pevent);
			}
			/// <summary>
			/// Use a timer tick to set the color and increment alpha
			/// </summary>
			/// <param name="sender"></param>
			/// <param name="e"></param>
			void timer_Tick(object sender, EventArgs e)
			{
				alpha+=10;
				color = Color.FromArgb(alpha, 150, 150, 25);
				if (alpha > 50) {
					timer.Stop();
				}
				Invalidate();
			}
			#endregion
		   
		}
	}
