    /// <summary>
    /// The ControlCloneEngine creates copies of ASP.NET controls
    /// </summary>
    public class ControlCloneEngine
    {
        private int m_instanceCount;
        public ControlCloneEngine()
        {
            m_instanceCount = 1;
        }
        /// <summary>
        /// Clone a control.  Call this function in Page_Init
        /// </summary>
        /// <param name="ctrlSource">The control to clone</param>
        /// <returns>a new copy of the control</returns>
        public Control Copy(Control ctrlSource)
        {
            Type t = ctrlSource.GetType();
            Control ctrlDest = (Control)t.InvokeMember("", BindingFlags.CreateInstance, null, null, null);
            foreach (PropertyInfo prop in t.GetProperties())
            {
                if (prop.CanWrite)
                {
                    if (prop.Name == "ID")
                    {
                        ctrlDest.ID = ctrlSource.ID + "c" + m_instanceCount;
                    }
                    else
                    {
                        prop.SetValue(ctrlDest, prop.GetValue(ctrlSource, null), null);
                    }
                }
            }
            m_instanceCount++;
            return ctrlDest;
        }
    }
