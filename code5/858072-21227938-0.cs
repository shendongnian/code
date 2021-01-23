    public void Main()
		{
			// TODO: Add your code here
            int sec = int.Parse(Dts.Variables["Timer"].Value.ToString());
            int row = Convert.ToInt32(Dts.Variables["IntRowCount"].Value.ToString());
            int ms = sec * 100;
            System.Threading.Thread.Sleep(ms);
            //Flag the IntRowCount variable to go out of the loop 
            if (row != 0)
            {
                Dts.Variables["IntRowCount"].Value = 0;
            }
            else
            {
                Dts.Variables["IntRowCount"].Value = 1;
            }
			Dts.TaskResult = (int)ScriptResults.Success;
		}
