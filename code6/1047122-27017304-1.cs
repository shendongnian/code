        ....
        /// <summary>
        /// Give all information about all screen on a single system
        /// </summary>
        public class ScreensInformations
        {
            #region Attributs
            /// <summary>
            /// Use to represents a display device or multiple display devices on a single system (Namespace System.Windows.Forms)
            /// </summary>              
            public Screen[] Screens { get; set; }
    
            /// <summary>
            /// Get the number of screen
            /// </summary>
            public int NumberScreen
            {
                get
                {
                    return this.Screens.Length;
                }
            }
            #endregion
    
            #region Constructor
            public ScreensInformations()
            {
                this.Screens = Screen.AllScreens;
            }
            #endregion
    
            #region Methods
            public override string ToString()
            {
                StringBuilder temp = new StringBuilder();
                int index = 1;
                temp.Append(" Number screens detected = "+this.NumberScreen+"\n");
                foreach (Screen screen in this.Screens)
                {
                    // For each screen, add the screen properties to a list box.
                    temp.Append("\n");
                    temp.Append(" > SCREEN " + index + "\n");
                    temp.Append("   ---------------------------------------------------------\n");
                    temp.Append("   |    Device Name : " + screen.DeviceName + "\n");
                    temp.Append("   |         Bounds : " + screen.Bounds.ToString() + "\n");
                    temp.Append("   |           Type : " + screen.GetType().ToString() + "\n");
                    temp.Append("   |   Working Area : " + screen.WorkingArea.ToString() + "\n");
                    temp.Append("   | Primary Screen : " + screen.Primary.ToString() + "\n");
                    temp.Append("   ---------------------------------------------------------\n");
                    index++;
                }
                return temp.ToString();
            }
            #endregion
        }
    
