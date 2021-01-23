    using System;
    using System.Drawing;
    using System.Collections;
    using System.ComponentModel;
    using System.Windows.Forms;
    using System.Data;
    using Microsoft.DirectX;
    using Microsoft.DirectX.DirectInput;
    
    namespace JoystickProject
    {
    	/// <summary>
    	/// Summary description for Form1.
    	/// </summary>
    	public class Form1 : System.Windows.Forms.Form
    	{
    		private System.Windows.Forms.Label label1;
    		/// <summary>
    		/// Required designer variable.
    		/// </summary>
    		private System.ComponentModel.Container components = null;
    		private Device device = null;
    		private bool running = true;
    		private ArrayList effectList = new ArrayList();
    		private bool button0pressed = false;
    		private string joyState = "";
    
    		public bool InitializeInput()
    		{
    			// Create our joystick device
    			foreach(DeviceInstance di in Manager.GetDevices(DeviceClass.GameControl,
    				EnumDevicesFlags.AttachedOnly | EnumDevicesFlags.ForceFeeback))
    			{
    				// Pick the first attached joystick we see
    				device = new Device(di.InstanceGuid);
    				break;
    			}
    			if (device == null) // We couldn't find a joystick
    				return false;
    
    			device.SetDataFormat(DeviceDataFormat.Joystick);
    			device.SetCooperativeLevel(this, CooperativeLevelFlags.Exclusive | CooperativeLevelFlags.Background);
    			device.Properties.AxisModeAbsolute = true;
    			device.Properties.AutoCenter = false;
    			device.Acquire();
    
    			// Enumerate any axes
    			foreach(DeviceObjectInstance doi in device.Objects)
    			{
    				if ((doi.ObjectId & (int)DeviceObjectTypeFlags.Axis) != 0)
    				{
    					// We found an axis, set the range to a max of 10,000
    					device.Properties.SetRange(ParameterHow.ById,
    						doi.ObjectId, new InputRange(-5000, 5000));
    				}
    			}
    
    			// Load our feedback file
    			EffectList effects = null;
    			effects = device.GetEffects(@"C:\MyEffectFile.ffe",
    				FileEffectsFlags.ModifyIfNeeded);
    			foreach(FileEffect fe in effects)
    			{
    				EffectObject myEffect = new EffectObject(fe.EffectGuid, fe.EffectStruct,
    					device);
    				myEffect.Download();
    				effectList.Add(myEffect);
    			}
    
    			while(running)
    			{
    				UpdateInputState();
    				Application.DoEvents();
    			}
    
    			return true;
    		}
    
    		private void PlayEffects()
    		{
    				// See if our effects are playing.
    				foreach(EffectObject myEffect in effectList)
    				{
    					//if (button0pressed == true)
    					//{
    						//MessageBox.Show("Button Pressed.");
    					//	myEffect.Start(1, EffectStartFlags.NoDownload);
    					//}
    
    					if (!myEffect.EffectStatus.Playing)
    					{
    						// If not, play them
    						myEffect.Start(1, EffectStartFlags.NoDownload);
    					}
    				}
    				//button0pressed = true;
    		}
    
    		protected override void OnClosed(EventArgs e)
    		{
    			running = false;
    		}
    
    		private void UpdateInputState()
    		{
    			PlayEffects();
    
    			// Check the joystick state
    			JoystickState state = device.CurrentJoystickState;
    			device.Poll();
    			joyState = "Using JoystickState: \r\n";
    
    			joyState += device.Properties.ProductName;
    			joyState += "\n";
    			joyState += device.ForceFeedbackState;
    			joyState += "\n";
    			joyState += state.ToString();
    
    			byte[] buttons = state.GetButtons();
    			for(int i = 0; i < buttons.Length; i++)
    				joyState += string.Format("Button {0} {1}\r\n", i, buttons[i] != 0 ? "Pressed" : "Not Pressed");
    
    			label1.Text = joyState;
    
    			//if(buttons[0] != 0)
    				//button0pressed = true;
    			
    		}
    
    		public Form1()
    		{
    			//
    			// Required for Windows Form Designer support
    			//
    			InitializeComponent();
    
    			//
    			// TODO: Add any constructor code after InitializeComponent call
    			//
    		}
    
    		/// <summary>
    		/// Clean up any resources being used.
    		/// </summary>
    		protected override void Dispose( bool disposing )
    		{
    			if( disposing )
    			{
    				if (components != null) 
    				{
    					components.Dispose();
    				}
    			}
    			base.Dispose( disposing );
    		}
    
    		#region Windows Form Designer generated code
    		/// <summary>
    		/// Required method for Designer support - do not modify
    		/// the contents of this method with the code editor.
    		/// </summary>
    		private void InitializeComponent()
    		{
    			this.label1 = new System.Windows.Forms.Label();
    			this.SuspendLayout();
    			// 
    			// label1
    			// 
    			this.label1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
    			this.label1.Location = new System.Drawing.Point(8, 8);
    			this.label1.Name = "label1";
    			this.label1.Size = new System.Drawing.Size(272, 488);
    			this.label1.TabIndex = 0;
    			// 
    			// Form1
    			// 
    			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
    			this.BackColor = System.Drawing.SystemColors.ControlText;
    			this.ClientSize = new System.Drawing.Size(288, 502);
    			this.Controls.AddRange(new System.Windows.Forms.Control[] {
    																		  this.label1});
    			this.Name = "Form1";
    			this.Text = "Joystick Stuff";
    			this.ResumeLayout(false);
    
    		}
    		#endregion
    
    		/// <summary>
    		/// The main entry point for the application.
    		/// </summary>
    		[STAThread]
    		static void Main() 
    		{
    			using (Form1 frm = new Form1())
    			{
    				frm.Show();
    				if (!frm.InitializeInput())
    					MessageBox.Show("Couldn't find a joystick.");
    			}
    		}
    	}
    }
