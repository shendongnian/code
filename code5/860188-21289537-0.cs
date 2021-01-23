        public List<T> GetControlsOfType<T>(ControlCollection controls)
        {
            List<T> ret = new List<T>();
            try
            {
                foreach (Control control in controls)
                {             
                        if (control is T)
                        {
                            ret.Add((T)((object)control));
                            break;
                        }
                        if (control.Controls.Count > 0)
                            ret.AddRange(GetControlsOfType<T>(control.Controls));                  
                }
            }
            catch (Exception ex)
            {
                //Log the exception
            }
            return ret;
        }
