var assembly = Assembly.GetExecutingAssembly();
var resourceName = "NamespaceName.FolderName.Sound.wav";   
using (Stream stream = assembly.GetManifestResourceStream(resourceName))
{
    var wave = new WaveFileReader(stream);
    Console.WriteLine(wave.TotalTime);
}
