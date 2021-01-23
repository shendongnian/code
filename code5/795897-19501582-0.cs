            Application app;
            try
            {
                app = (Application)System.Runtime.InteropServices.Marshal.GetActiveObject("Word.Application");
            }
            catch
            {
                app = new Application();
            }
