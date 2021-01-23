    public class FileProcessor
    {
        private string _myFileName;
        public void Run()
        {
            try
            {
                var fileLoader = new FileLoader();
                Process(fileLoader.Load(_myFileName));
            }
            catch (FileNotFoundException)
            {
                throw new RijException("Can't find requested file");
            }
            
        }
        private void Process(object file)
        {
            //some logic
        }
    }
    public class FileLoader
    {
        public object Load(string myFileName)
        {
            //throws FileNotFoundException
        }
    }
