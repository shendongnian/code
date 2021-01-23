    public interface IDatabaseLog: ILog
    {
    }
    
    public interface IFileLog: ILog
    {
    }
    
    public class DatabaseLogger: IDatabaseLog
    {
    }
    
    public class FileLogger: IFileLog
    {
    }
    public Dependant(IDatabaseLog dbLog, IFileLog fsLog)
    {
     //useful code
    }
