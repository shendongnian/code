    public class MyClass
    {
        private SshMagic _sshMagic = new SshMagic(); // or something like that
        
        ...
        ResultObject getServerStatus(string ip,string user,string pass,...)
        {
            if (..)
            {
               return _sshMagic.Something();
            }
            else
            {
                ...
            }
        }
    }
