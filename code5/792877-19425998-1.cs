    public interface ISshMagic
    {
        ...
        ResultObject Something();
        ...   
    }
    public class MyClass
    {
        private ISshMagic _sshMagic;
        
        public MyClass(ISshMagic sshMagic)
        {
            _sshMagic = sshMagic;
        }
        ...
    }
