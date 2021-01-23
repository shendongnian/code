    public class Sut
    {
        public bool SomeMethod()
        {
            var dlg = new OpenFileDialog();
            var result = dlg.ShowDialog();
            return result.Value;
        }
    }
