    public static class Constantes
    {
        public const String DateTimePattern = "yyyyMMddHHmmss";
    }
    public class SaveProcessViewModel : NotificationObject
    {
    [...]
        String zipFileName = System.Environment.MachineName + "-" + DateTime.Now.ToString(Constantes.DateTimePattern) + ".zip";
        String tempZipFile = Path.Combine(Path.GetTempPath(), zipFileName);
        zip.Save(tempZipFile);
    [...]
    }
