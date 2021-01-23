    public class TestVisualizer : DialogDebuggerVisualizer
    {
        protected override void Show(IDialogVisualizerService windowService, IVisualizerObjectProvider objectProvider)
        {
            string command;
            try
            {
                command = new StreamReader(objectProvider.GetData()).ReadLine();
                MessageBox.Show(command);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
