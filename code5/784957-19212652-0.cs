    //---------------------  1  ----------------------------------
 
                System.Reflection.Assembly app = System.Reflection.Assembly.LoadFrom("c:\\Windows\\ConsoleApp.exe");
                Type[] types = app.GetTypes();
                foreach (Type type in types)
                {
                    System.Reflection.MethodInfo method = type.GetMethod("Main", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic);
                    if (method != null)
                    {
                    tryAgain:
                        ;
                        try
                        {
                            method.Invoke(null, null);
                        }
                        catch (Exception ex)
                        {
                            System.Threading.Thread.Sleep(2000); // Wait for 2 seconds if u wish..
                            goto tryAgain;
                        }
                        break;
                    }
                }
.
.
    //--------------------------------------------- 2 -------------------------------------
    void init()
    {
        loadProcess();
    }
    
            void loadProcess()
            {
                System.Threading.Thread.Sleep(2000);
                System.Diagnostics.Process prc = new System.Diagnostics.Process();
                prc.StartInfo.FileName = "C:\\Windows\\ConsoleApp.exe";
                prc.Exited += new EventHandler(prc_Exited);  // Event Handler when the process is exited. (Mostly not working 4 me)
                prc.Start();
            }
    
            void prc_Exited(object sender, EventArgs e)
            {
                loadProcess();
                
            }
