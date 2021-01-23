    interface IWalker
    {
        void Walker(object a=null, object b=null);
    }
    class RegistryList: IWalker
    {
        public void Walker(object a, object b){
            var _key = (RegistryKey)a;
            var _indent = Convert.ToInt32(b)
            RegistryWalker(_key, _indent)
        }
        private void RegistryWalker(RegistryKey _key, int _indent)
        { 
            ....
        }
    }
    class FileListIWalker
    {
        public void Walker(object a=null, object b=null){
            FileWalker();
        }
        public void FileWalker(){...}
    {
