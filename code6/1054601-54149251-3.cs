    public void Main()
    		{
                // TODO: Add your code here
                    MessageBox.Show("ID = " + Dts.Variables["User::ProcID"].Value + ", and val = " + Dts.Variables["User::TaskID"].Value, "Name = Result");
    
                    Dts.TaskResult = (int)ScriptResults.Success;
             
            }
